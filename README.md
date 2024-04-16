# FileToDB Connector

The FileToDB Connector is a C# Windows Forms application designed to read and process text files containing data about movies, users, and ratings. It allows users to upload one or more text files, processes the data, and inserts it into a database. The application includes features such as error handling, logging, and progress tracking.


## Technologies Used

- C#
- Windows Forms
- .NET Framework
- Microsoft SQL Server (for database operations)

## Features

- **User Interface**: The application provides a user-friendly interface with progress reporting functionality to keep users informed about the status of file processing and database insertion.  
- **Upload Text Files**: Users can upload one or multiple text files (.txt) containing data.
- **Database Connection Management**: Consider using connection pooling and implementing proper connection open/close mechanisms to minimize resource usage and improve performance.
- **Process Files**: The application processes the uploaded files, extracting relevant information and inserting it into a database.
- **Logging**: Implement logging and auditing features to record important events, actions, and errors that occur within the application.  
- **Error Handling and Reporting**: Implement robust error handling mechanisms to gracefully handle errors that may occur during file reading, data processing, or database insertion.

## Installation Instruction

1. Clone or download the project repository.
2. Open the solution file in Visual Studio.
3. Build the solution to restore dependencies.
4. Configure the database connection string in the application.
5. Run the application.

## Usage

1. Launch the application.

2. Click on the "Upload Files" button to select one or more text files containing data (movies, users, or ratings).

3. Once files are uploaded, click on the "Start" button to begin processing the files or or "Cancel" to come back to the Upload Files button.

4. Progress indicators will show the processing status.
- **File Name**: Indicates the name of the file currently being processed.
- **Percentage**: Shows the completion percentage of the processing task.
- **Number of Records**: Displays the total number of records being processed.
- **Alerts**: Displays the alerts occured during the process.

5. After processing, users can view a log with details operations, alerts and numbers of records inserted ckick on the See Log button.

## Contributing Guidelines

Contributions to this project are welcome. Please follow these guidelines:
- Fork the repository.
- Make your changes.
- Submit a pull request, explaining the changes you've made.

## License Information

This project is licensed under the [MIT License](LICENSE)

## Documentation Links
For more detailed documentation, refer to [Wiki](https://github.com/RosaNunezRivera/read-file-desktop-application/wiki).


## Project Structure

- Form1.cs: Main form containing the application logic.
- README.md: Project documentation.

## Testing Instructions

To test the application:
1. Prepare sample text files with movie, user, and rating data.
2. Run the application and upload the sample files.
3. Verify that the data is processed correctly and inserted into the database.

## Contact Information

For questions or support, contact [Rosa Nunez](mailto:rosamnunezrivera@gmail.com).

## Acknowledgements

- Mention any individuals or organizations you'd like to acknowledge for their contributions or support.

## Version History

- v1.0 (2024-04-14): Initial release
- v1.1 (2024-04-16): Wiki page and Readme.md improvements

## Code Example

```csharp
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
```