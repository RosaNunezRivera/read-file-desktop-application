using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace ReadFilwebApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creating a method to show a button to upload .txt file(s) 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpload_Click(object sender, EventArgs e)
        {
            try
            {
                //Creating the object type OpenFileDialog to allows the user upload files
                OpenFileDialog openFileDialog = new OpenFileDialog();

                //Set filter that only txt file can be uploaded 
                openFileDialog.Filter = "(*.txt)|*.txt";

                //Allowing to the user upload more one file at the same time 
                openFileDialog.Multiselect = true;

                openFileDialog.ShowDialog();

                //Cleaning the listBox in case the user is re doing the action 
                listBox.Items.Clear();

                //Adding the files uploaded by the use to a lixtBox object
                foreach (string file in openFileDialog.FileNames)
                {
                    listBox.Items.Add(file);
                }

                //Making visible the listbox filled with the route of the files loaded 
                //and the button start
                if (listBox.Items.Count == 0)
                {
                    MessageBox.Show("Plase select at least one file");
                }
                else
                {
                    listBox.Visible = true;
                    buttonStart.Visible = true;
                    buttonCancel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error was occurred: " + ex.Message);
            }
        }
        /// <summary>
        /// Method for button cancel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            listBox.Visible = false;
            buttonStart.Visible = false;
            buttonCancel.Visible = false;
        }

        /// <summary>
        /// Method for Start button to read the files and perfomes the operations in the DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                //Desactivating button Upload
                buttonUpload.Enabled = false;

                //To represents one \ it must use doble because only one because a single backslash is interpreted as an escape character. 
                string characterToSplit = "\\";

                //Getting the user path 
                string actualPath = listBox.Items[0].ToString();

                //Getting the actual path spliced by \ 
                string[] actualPathSplited = actualPath.Split(characterToSplit);

                //Get the file path (full path without the last element (file name) 
                string filesPath = string.Join("\\", actualPathSplited.Take(actualPathSplited.Length - 1)) + "\\";

                //Creating the path for the logreadme.txt
                string logFilePath = string.Join("\\", actualPathSplited.Take(actualPathSplited.Length - 1)) + "\\logFileToDBConnector.txt";

                //Creating the log file
                CreateLogFile(logFilePath);
                WriteLogFile(logFilePath, "Files path " + filesPath);
                WriteLogFile(logFilePath, "Logfile path " + logFilePath);

                general.Text = logFilePath;

                buttonStart.Visible = false;
                buttonCancel.Visible = false;

                //Making Visible objects related to processing process
                panel2.BorderStyle = BorderStyle.FixedSingle;
                panel2.Visible = true;
                labelProcessingFile.Visible = true;
                labelProcessingFile.Refresh();
                labelProcess.Visible = true;
                labelProcess.Refresh();
                labelAlerts.Visible = true;
                labelAlerts.Refresh();
                percent.Visible = true;
                alerts.Visible = true;
                regProcessing.Visible = true;
                //Dictionary to create a list of files with the order of processing 
                Dictionary<int, string> orderToRead = new Dictionary<int, string>();
                orderToRead.Add(1, "Movies.txt");
                orderToRead.Add(2, "Users.txt");
                orderToRead.Add(3, "Ratings.txt");

                //Declaring variables to store in a Dictionary the file name, path and bool status 
                string fileName = "";
                string[] lineDic;
                string fileNamePath;
                Dictionary<int, (string, string)> filesToRead = new Dictionary<int, (string, string)>();
                for (int i = 0; i <= listBox.Items.Count - 1; i++)
                {
                    lineDic = listBox.Items[i].ToString().Split(characterToSplit);
                    fileName = lineDic[lineDic.Length - 1];
                    fileNamePath = @filesPath + fileName;

                    int orderFile = 0;
                    if (orderToRead.ContainsValue(fileName))
                    {
                        orderFile = orderToRead.FirstOrDefault(x => x.Value == fileName).Key;
                    }

                    filesToRead.Add(orderFile, (fileName, fileNamePath));
                }

                //Interacting the dictionary to read file by file
                foreach (var order in filesToRead.Keys.OrderBy(k => k))
                {
                    var fileAndPath = filesToRead[order];
                    string fileNameDic = fileAndPath.Item1;
                    string filePathDic = fileAndPath.Item2;
                    //Reading the files choosen by the user 
                    ReadFile(filePathDic, fileNameDic, logFilePath);
                }

                //Showing the button Continue
                buttonContinue.Visible = true;
                buttonSeeLog.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error was occurred: " + ex.Message);
            }
        }

        /// <summary>
        /// Method to call a specific method to read a single file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <param name="logFilePath"></param>
        private void ReadFile(string filePath, string fileName, string logFilePath)
        {
            try
            {
                switch (fileName)
                {
                    case "Movies.txt":
                        ReadMoviesFile(filePath, fileName, logFilePath);
                        break;
                    case "Users.txt":
                        ReadUsersFile(filePath, fileName, logFilePath);
                        break;
                    case "Ratings.txt":
                        ReadRatingsFile(filePath, fileName, logFilePath);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error was occurred: " + ex.Message);
            }
        }


        /// <summary>
        /// Method to implement the button Continue - to start again
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonContinue_Click(object sender, EventArgs e)
        {
            //Reset the variables and objects 
            panel2.Visible = false;
            listBox.Items.Clear();
            listBox.Visible = false;
            fileProcessing.Visible = false;
            buttonUpload.Enabled = true;
            fileProcessing.Clear();
            alerts.Clear();
        }

        /// <summary>
        /// Method to see the log file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSeeLog_click(object sender, EventArgs e)
        {
            try
            {
                var fileToOpen = general.Text;
                var process = new Process();
                process.StartInfo = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    FileName = fileToOpen
                };
                process.Start();
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                alerts.AppendText("Close the logfile to continue");
                alerts.Refresh();
            }
        }

        /// <summary>
        /// Method to read Users file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="actualFile"></param>
        /// <param name="logFilePath"></param>
        private void ReadUsersFile(string filePath, string actualFile, string logFilePath)
        {
            //Declaring variables
            int registerCounter = 0;
            int registerInserted = 0;
            int registerNoInserted = 0;
            int alertCounter = 0;

            //Setting objects in the form
            fileProcessing.Visible = true;
            fileProcessing.Text = actualFile;
            fileProcessing.Refresh();

            //Start to update the logfile
            WriteLogFile(logFilePath, $"---------File: {actualFile} ---------");
            WriteLogFile(logFilePath, $"Starting to read the file {actualFile}");

            //Create object to open the file in mode only read mode
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            //Encoding.GetEncoding("iso-8859-1") Help to read specials characteres
            int bufferSize = 128 * 1024;

            using (StreamReader read = new StreamReader(fileStream, Encoding.GetEncoding("iso-8859-1"), true, bufferSize))
            {
                //Declaring variables to read the file
                string line;
                string occupation = "";
                string zipCode = "";
                bool validRegister = true;

                //Set the maxium value of the progress bar (Total of lines of the file)
                //Declaring values for the process bar 
                progressBar.Step = 1;
                progressBar.Value = 0;
                progressBar.Maximum = File.ReadLines(filePath).Count();
                progressBar.ForeColor = Color.Blue;
                progressBar.Visible = true;

                //Reading the file line by line
                while ((line = read.ReadLine()) != null)
                {
                    //Couting the lines as a registers
                    registerCounter++;

                    //Setting the value of the progressBar to show the performance
                    progressBar.Value = registerCounter;
                    double perce = ((double)progressBar.Value / progressBar.Maximum) * 100;
                    percent.Text = $"{perce:F0}%";
                    percent.Refresh();
                    regProcessing.Text = $"Registers {progressBar.Value.ToString()} / {progressBar.Maximum.ToString()}";
                    regProcessing.Refresh();

                    try
                    {
                        //Creating a array type string to store each one word in the line
                        string[] words = line.Split('|');

                        for (int i = 0; i <= words.Length - 1; i++)
                        {
                            //Getting the userId
                            if (!int.TryParse(words[0], out int userId))
                            {
                                validRegister = false;
                            }

                            //Getting the age
                            if (!int.TryParse(words[1], out int age))
                            {
                                validRegister = false;
                            }

                            //Getting the gender
                            if (!char.TryParse(words[2], out char gender))
                            {
                                validRegister = false;
                            }

                            //Getting the occupation and zipCode
                            if (words[3] != null)
                            {
                                occupation = words[3];
                            }
                            else
                            {
                                validRegister = false;
                            }

                            if (words[4] != null)
                            {
                                zipCode = words[4];
                            }
                            else
                            {
                                validRegister = false;
                            }


                            if (i == words.Length - 1 && validRegister == true)
                            {
                                bool successInsert = InsertUsers(userId, age, gender, occupation, zipCode);

                                if (successInsert)
                                {
                                    registerInserted++;
                                }
                                else
                                {
                                    registerNoInserted++;
                                    alertCounter++;
                                    WriteLogFile(logFilePath, $"Alert {alertCounter}: Register no inserted with UserID {userId}");

                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        alertCounter++;
                        WriteLogFile(logFilePath, $"Alert {alertCounter}: Error reading the file users {ex.Message}");
                    }
                }
            }
            WriteLogFile(logFilePath, "Reading the file has been completed");
            WriteLogFile(logFilePath, $"Total Records read {registerCounter}");
            WriteLogFile(logFilePath, $"Records inserted {registerInserted}");
            WriteLogFile(logFilePath, $"Records not inserted {registerNoInserted}");

            alerts.AppendText($"File {actualFile}: {alertCounter} alerts in logfile" + Environment.NewLine);
            alerts.Refresh();
        }

        /// <summary>
        /// Create log file
        /// </summary>
        /// <param name="filePath"></param>
        static void CreateLogFile(string filePath)
        {
            //True means append. Without second parameter true overwrite the file.
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("FileToDB Connector");
                writer.WriteLine("Logfile for read operations");
            }
        }

        /// <summary>
        /// Method to add new information in logfile 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="newline"></param>
        static void WriteLogFile(string filePath, string newline)
        {
            //True means append. Without second parameter true overwrite the file.
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(DateTime.Now + " | " + newline);
            }
        }

        /// <summary>
        /// Method to read the file of movies to get general information about movies
        /// </summary>
        /// <param name="filePath"></param>
        private void ReadMoviesFile(string filePath, string actualFile, string logFilePath)
        {
            int registerCounter = 0;
            int registerInserted = 0;
            int registerNoInserted = 0;
            int alertCounter = 0;

            WriteLogFile(logFilePath, $"---------File: {actualFile} ---------");
            WriteLogFile(logFilePath, $"Starting to read the file {actualFile}");

            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            int bufferSize = 128 * 1024;

            fileProcessing.Visible = true;
            fileProcessing.Text = actualFile;
            fileProcessing.Refresh();

            //Set the maxium value of the progress bar (Total of lines of the file)
            //Declaring values for the process bar 
            progressBar.Step = 1;
            progressBar.Value = 0;
            progressBar.Maximum = File.ReadLines(filePath).Count();
            progressBar.Visible = true;

            using (StreamReader read = new StreamReader(fileStream, Encoding.GetEncoding("iso-8859-1"), true, bufferSize))
            {
                //Declaring variables
                string line;
                string title = "";
                string imdbLink = "";

                while ((line = read.ReadLine()) != null)
                {
                    registerCounter++;
                    progressBar.Value = registerCounter;
                    double perce = ((double)progressBar.Value / progressBar.Maximum) * 100;
                    percent.Text = $"{perce:F0}%";
                    percent.Refresh();
                    regProcessing.Text = $"Registers {progressBar.Value.ToString()} / {progressBar.Maximum.ToString()}";
                    regProcessing.Refresh();
                    try
                    {
                        string[] words = line.Split('|');

                        for (int i = 0; i <= words.Length - 1; i++)
                        {
                            //Getting the movieId
                            if (!int.TryParse(words[0], out int movieId))
                            {
                                //Cannot parse
                            }

                            //Getting the title
                            title = words[1];


                            //Getting the releaseDate
                            if (DateTime.TryParse(words[2], out DateTime releaseDate))
                            {
                                //Invalid
                            }


                            //words[3] is empty 

                            //Getting the IMDbLink
                            imdbLink = words[4];

                            bool[] genres = new bool[24];
                            for (int ii = 5; ii < words.Length; ii++)
                            {
                                if (words[ii] == "1")
                                {
                                    genres[ii] = true;
                                }
                                else
                                {
                                    genres[ii] = false;
                                }
                            }

                            if (i == words.Length - 1)
                            {
                                bool successInsert = InsertMovies(movieId, title, releaseDate, imdbLink, genres[5], genres[6], genres[7], genres[8], genres[9], genres[10], genres[11], genres[12], genres[13], genres[14], genres[15], genres[16], genres[17], genres[18], genres[19], genres[20], genres[21], genres[22], genres[23]);

                                if (successInsert)
                                {
                                    registerInserted++;
                                }
                                else
                                {
                                    registerNoInserted++;
                                    alertCounter++;
                                    WriteLogFile(logFilePath, $"Alert {alertCounter}: Register no inserted with MovieID {movieId}");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        alertCounter++;
                        WriteLogFile(logFilePath, $"Alert {alertCounter}: Error reading the file movies {ex.Message}");
                    }
                }
            }
            WriteLogFile(logFilePath, "Reading the file has been completed");
            WriteLogFile(logFilePath, $"Total Records read {registerCounter}");
            WriteLogFile(logFilePath, $"Records inserted {registerInserted}");
            WriteLogFile(logFilePath, $"Records not inserted {registerNoInserted}");

            alerts.AppendText($"File {actualFile}: {alertCounter} alerts in logfile" + Environment.NewLine);
            alerts.Refresh();
        }

        /// <summary>
        /// Method to read the file ratings to get all information to insert into a table
        /// </summary>
        /// <param name="filePath"></param>
        private void ReadRatingsFile(string filePath, string actualFile, string logFilePath)
        {
            WriteLogFile(logFilePath, $"---------File: {actualFile} ---------");
            WriteLogFile(logFilePath, $"Starting to read the file {actualFile}");

            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            DateTime timeStamp = DateTime.MinValue; // Initialize to a default value
            int registerCounter = 0;
            int registerInserted = 0;
            int registerNoInserted = 0;
            int alertCounter = 0;

            //To increment the speed to read the file of ratings (almost 100 k)
            int bufferSize = 128 * 1024;

            fileProcessing.Visible = true;
            fileProcessing.Text = actualFile;
            fileProcessing.Refresh();

            //Set the maxium value of the progress bar (Total of lines of the file)
            //Declaring values for the process bar 
            progressBar.Step = 1;
            progressBar.Value = 0;
            progressBar.Maximum = File.ReadLines(filePath).Count();
            progressBar.Visible = true;

            using (StreamReader read = new StreamReader(fileStream, Encoding.GetEncoding("iso-8859-1"), true, bufferSize))
            {
                //Declaring variables
                string line;
                bool validRegister = true;

                while ((line = read.ReadLine()) != null)
                {
                    registerCounter++;
                    progressBar.Value = registerCounter;
                    double perce = ((double)progressBar.Value / progressBar.Maximum) * 100;
                    percent.Text = $"{perce:F0}%";
                    percent.Refresh();
                    regProcessing.Text = $"Registers {progressBar.Value.ToString()} / {progressBar.Maximum.ToString()}";
                    regProcessing.Refresh();
                    try
                    {
                        string[] words = line.Split('\t');

                        for (int i = 0; i <= words.Length - 1; i++)
                        {
                            //Getting the userId
                            if (!int.TryParse(words[0].Trim(), out int userId))
                            {
                                validRegister = false;
                            }

                            //Getting the movieId
                            if (!int.TryParse(words[1].Trim(), out int movieId))
                            {
                                validRegister = false;
                            }

                            //Getting the raring
                            if (!int.TryParse(words[2].Trim(), out int rating))
                            {
                                validRegister = false;
                            }

                            //Getting the TimeStamp
                            if (int.TryParse(words[i].Trim(), out int unixTimeStamp))
                            {
                                //object that represents a specific date and time in time. It is set to the
                                //Unix epoch, which is January 1, 1970, at 00:00:00
                                //Coordinated Universal Time (UTC).
                                //Adding the unixTimeStamp to convert into a DateTime format date and time.
                                timeStamp = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                                    .AddSeconds(unixTimeStamp);//adds the number of seconds specified by unixTimeStamp to this initial date.
                            }
                            else
                            {
                                validRegister = false;
                            }


                            if (i == words.Length - 1 && validRegister == true)
                            {
                                bool successinsert = InsertRatings(userId, movieId, rating, timeStamp);
                                if (successinsert)
                                {
                                    registerInserted++;
                                }
                                else
                                {
                                    registerNoInserted++;
                                    alertCounter++;
                                    WriteLogFile(logFilePath, $"Alert {alertCounter}: Register no inserted in Ratings with MovieID {movieId}");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        alertCounter++;
                        WriteLogFile(logFilePath, $"Alert {alertCounter}: Error reading the file Ratings {ex.Message}");

                    }
                }
            }

            WriteLogFile(logFilePath, "Reading the file has been completed");
            WriteLogFile(logFilePath, $"Total Records read {registerCounter}");
            WriteLogFile(logFilePath, $"Records inserted {registerInserted}");
            WriteLogFile(logFilePath, $"Records not inserted {registerNoInserted}");

            alerts.AppendText($"File {actualFile}: {alertCounter} alerts in logfile" + Environment.NewLine);
            alerts.Refresh();
        }

        /// <summary>
        /// Method to insert in the table the data retrieved from the file
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="age"></param>
        /// <param name="gender"></param>
        /// <param name="occupation"></param>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        private bool InsertUsers(int userId, int age, char gender, string occupation, string zipCode)
        {
            string connectionString = "Data Source=.;Initial Catalog=Movies;Integrated Security=True;Encrypt=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("usp_InsertUsers", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                bool result = false;
                try
                {
                    //Parameter to be accepted by the store procedure
                    sqlCommand.Parameters.AddWithValue("@userID", userId);
                    sqlCommand.Parameters.AddWithValue("@age", age);
                    sqlCommand.Parameters.AddWithValue("@gender", gender);
                    sqlCommand.Parameters.AddWithValue("@occupation", occupation);
                    sqlCommand.Parameters.AddWithValue("@zipCode", zipCode);

                    connection.Open();
                    int i = sqlCommand.ExecuteNonQuery();//1 successfull conection
                    connection.Close();

                    if (i > 0)
                    {
                        result = true;
                    }
                }
                catch (Exception ex)
                {
                    alerts.AppendText($"File Users.txt: Error ocurred in UserId {userId} trying to insert\n");
                    alerts.Refresh();
                }
                return result;
            }
        }

        /// <summary>
        /// Method to insert in the table information retrieved from movies file
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="title"></param>
        /// <param name="releaseDate"></param>
        /// <param name="imdbLink"></param>
        /// <param name="action"></param>
        /// <param name="adventure"></param>
        /// <param name="comedy"></param>
        /// <param name="drama"></param>
        /// <param name="romance"></param>
        /// <param name="thriller"></param>
        /// <param name="scienceFiction"></param>
        /// <param name="animation"></param>
        /// <param name="fantasy"></param>
        /// <param name="horror"></param>
        /// <param name="musical"></param>
        /// <param name="mystery"></param>
        /// <param name="documentary"></param>
        /// <param name="war"></param>
        /// <param name="crime"></param>
        /// <param name="western"></param>
        /// <param name="filmNoir"></param>
        /// <param name="childrens"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        private bool InsertMovies(int movieId, string title, DateTime releaseDate, string imdbLink, bool action, bool adventure, bool comedy, bool drama, bool romance, bool thriller, bool scienceFiction, bool animation, bool fantasy, bool horror, bool musical, bool mystery, bool documentary, bool war, bool crime, bool western, bool filmNoir, bool childrens, bool other)
        {
            string connectionString = "Data Source=.;Initial Catalog=Movies;Integrated Security=True;Encrypt=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("usp_InsertMovies", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                bool result = false;
                try
                {
                    //Parameter to be accepted by the store procedure
                    sqlCommand.Parameters.AddWithValue("@movieID", movieId);
                    sqlCommand.Parameters.AddWithValue("@title", title);
                    sqlCommand.Parameters.AddWithValue("@releaseDate", releaseDate);
                    sqlCommand.Parameters.AddWithValue("@imdbLink", imdbLink);
                    sqlCommand.Parameters.AddWithValue("@action", action);
                    sqlCommand.Parameters.AddWithValue("@adventure", adventure);
                    sqlCommand.Parameters.AddWithValue("@comedy", comedy);
                    sqlCommand.Parameters.AddWithValue("@drama", drama);
                    sqlCommand.Parameters.AddWithValue("@romance", romance);
                    sqlCommand.Parameters.AddWithValue("@thriller", thriller);
                    sqlCommand.Parameters.AddWithValue("@scienceFiction", scienceFiction);
                    sqlCommand.Parameters.AddWithValue("@animation", animation);
                    sqlCommand.Parameters.AddWithValue("@fantasy", fantasy);
                    sqlCommand.Parameters.AddWithValue("@horror", horror);
                    sqlCommand.Parameters.AddWithValue("@musical", musical);
                    sqlCommand.Parameters.AddWithValue("@mystery", mystery);
                    sqlCommand.Parameters.AddWithValue("@documentary", documentary);
                    sqlCommand.Parameters.AddWithValue("@war", war);
                    sqlCommand.Parameters.AddWithValue("@crime", crime);
                    sqlCommand.Parameters.AddWithValue("@western", western);
                    sqlCommand.Parameters.AddWithValue("@filmNoir", filmNoir);
                    sqlCommand.Parameters.AddWithValue("@childrens", childrens);
                    sqlCommand.Parameters.AddWithValue("@other", other);

                    connection.Open();
                    int i = sqlCommand.ExecuteNonQuery();//1 successfull conection
                    connection.Close();

                    if (i > 0)
                    {
                        result = true;
                    }
                }
                catch (Exception ex)
                {
                    alerts.AppendText($"File Movies.txt: Error ocurred in MovieID {movieId} trying to insert\n");
                    alerts.Refresh();
                }
                return result;
            }
        }

        /// <summary>
        /// Method to insert ratings in the table
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="movieId"></param>
        /// <param name="rating"></param>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        private bool InsertRatings(int userId, int movieId, int rating, DateTime timeStamp)
        {
            string connectionString = "Data Source =.;Initial Catalog=Movies;Integrated Security=True;Encrypt=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("usp_InsertRatings", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                bool result = false;
                try
                {
                    //Parameter to be accepted by the store procedure
                    sqlCommand.Parameters.AddWithValue("@userID", userId);
                    sqlCommand.Parameters.AddWithValue("@movieID", movieId);
                    sqlCommand.Parameters.AddWithValue("@rating", rating);
                    sqlCommand.Parameters.AddWithValue("@timeStamp", timeStamp);

                    connection.Open();
                    int i = sqlCommand.ExecuteNonQuery();//1 successfull conection
                    connection.Close();

                    if (i > 0)
                    {
                        result = true;
                    }
                }
                catch (Exception ex)
                {
                    alerts.AppendText($"File Ratings.txt: Error ocurred in UserID {userId} trying to insert\n");
                    alerts.Refresh();
                }
                return result;
            }
        }
    }
}
