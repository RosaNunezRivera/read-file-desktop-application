namespace ReadFilwebApplication
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            buttonUpload = new Button();
            openFileDialog1 = new OpenFileDialog();
            title = new Label();
            splitContainer1 = new SplitContainer();
            pictureBox1 = new PictureBox();
            general = new TextBox();
            panel2 = new Panel();
            regProcessing = new Label();
            percent = new Label();
            alerts = new TextBox();
            labelAlerts = new Label();
            buttonSeeLog = new Button();
            buttonContinue = new Button();
            labelProcess = new Label();
            labelProcessingFile = new TextBox();
            fileProcessing = new TextBox();
            progressBar = new ProgressBar();
            textBox2 = new TextBox();
            buttonStart = new Button();
            listBox = new ListBox();
            buttonCancel = new Button();
            panel1 = new Panel();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // buttonUpload
            // 
            buttonUpload.AutoSize = true;
            buttonUpload.BackColor = Color.SteelBlue;
            buttonUpload.FlatAppearance.BorderSize = 0;
            buttonUpload.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
            buttonUpload.FlatAppearance.MouseOverBackColor = Color.SteelBlue;
            buttonUpload.FlatStyle = FlatStyle.Popup;
            buttonUpload.Font = new Font("Arial Unicode MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonUpload.ForeColor = SystemColors.ButtonHighlight;
            buttonUpload.Location = new Point(154, 8);
            buttonUpload.Name = "buttonUpload";
            buttonUpload.Size = new Size(303, 32);
            buttonUpload.TabIndex = 0;
            buttonUpload.Text = "Upload Files";
            buttonUpload.UseVisualStyleBackColor = false;
            buttonUpload.Click += buttonUpload_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // title
            // 
            title.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            title.AutoSize = true;
            title.BackColor = Color.Transparent;
            title.CausesValidation = false;
            title.Font = new Font("Arial Unicode MS", 24F, FontStyle.Bold, GraphicsUnit.Point);
            title.ForeColor = SystemColors.ButtonHighlight;
            title.Location = new Point(233, 7);
            title.Name = "title";
            title.Size = new Size(329, 43);
            title.TabIndex = 3;
            title.Text = "FileToDB Connector";
            title.TextAlign = ContentAlignment.TopCenter;
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(2, 86);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.AccessibleRole = AccessibleRole.OutlineButton;
            splitContainer1.Panel1.Controls.Add(pictureBox1);
            splitContainer1.Panel1.Controls.Add(general);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.ButtonHighlight;
            splitContainer1.Panel2.Controls.Add(panel2);
            splitContainer1.Panel2.Controls.Add(textBox2);
            splitContainer1.Panel2.Controls.Add(buttonStart);
            splitContainer1.Panel2.Controls.Add(listBox);
            splitContainer1.Panel2.Controls.Add(buttonUpload);
            splitContainer1.Panel2.Controls.Add(buttonCancel);
            splitContainer1.Size = new Size(800, 370);
            splitContainer1.SplitterDistance = 279;
            splitContainer1.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = null;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(276, 367);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // general
            // 
            general.BackColor = Color.LightGray;
            general.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            general.ForeColor = SystemColors.Info;
            general.Location = new Point(212, 292);
            general.Multiline = true;
            general.Name = "general";
            general.Size = new Size(52, 13);
            general.TabIndex = 15;
            general.TextAlign = HorizontalAlignment.Center;
            general.Visible = false;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonHighlight;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(regProcessing);
            panel2.Controls.Add(percent);
            panel2.Controls.Add(alerts);
            panel2.Controls.Add(labelAlerts);
            panel2.Controls.Add(buttonSeeLog);
            panel2.Controls.Add(buttonContinue);
            panel2.Controls.Add(labelProcess);
            panel2.Controls.Add(labelProcessingFile);
            panel2.Controls.Add(fileProcessing);
            panel2.Controls.Add(progressBar);
            panel2.Location = new Point(67, 124);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(5);
            panel2.Size = new Size(390, 239);
            panel2.TabIndex = 12;
            panel2.Visible = false;
            // 
            // regProcessing
            // 
            regProcessing.AutoSize = true;
            regProcessing.ForeColor = Color.Navy;
            regProcessing.Location = new Point(240, 50);
            regProcessing.Name = "regProcessing";
            regProcessing.Size = new Size(74, 15);
            regProcessing.TabIndex = 15;
            regProcessing.Text = "Registers 0/0";
            regProcessing.TextAlign = ContentAlignment.MiddleCenter;
            regProcessing.Visible = false;
            // 
            // percent
            // 
            percent.AutoSize = true;
            percent.ForeColor = Color.Navy;
            percent.Location = new Point(86, 50);
            percent.Name = "percent";
            percent.Size = new Size(23, 15);
            percent.TabIndex = 14;
            percent.Text = "0%";
            percent.TextAlign = ContentAlignment.MiddleCenter;
            percent.Visible = false;
            // 
            // alerts
            // 
            alerts.BackColor = Color.IndianRed;
            alerts.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            alerts.ForeColor = SystemColors.Info;
            alerts.Location = new Point(24, 135);
            alerts.Multiline = true;
            alerts.Name = "alerts";
            alerts.ScrollBars = ScrollBars.Vertical;
            alerts.Size = new Size(340, 45);
            alerts.TabIndex = 16;
            alerts.Visible = false;
            // 
            // labelAlerts
            // 
            labelAlerts.AutoSize = true;
            labelAlerts.ForeColor = Color.Navy;
            labelAlerts.Location = new Point(24, 117);
            labelAlerts.Name = "labelAlerts";
            labelAlerts.Size = new Size(37, 15);
            labelAlerts.TabIndex = 14;
            labelAlerts.Text = "Alerts";
            // 
            // buttonSeeLog
            // 
            buttonSeeLog.AutoSize = true;
            buttonSeeLog.BackColor = Color.LightSkyBlue;
            buttonSeeLog.FlatAppearance.BorderSize = 0;
            buttonSeeLog.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
            buttonSeeLog.FlatAppearance.MouseOverBackColor = Color.SteelBlue;
            buttonSeeLog.FlatStyle = FlatStyle.Popup;
            buttonSeeLog.Font = new Font("Arial Unicode MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonSeeLog.ForeColor = SystemColors.ButtonHighlight;
            buttonSeeLog.Location = new Point(214, 193);
            buttonSeeLog.Name = "buttonSeeLog";
            buttonSeeLog.Size = new Size(108, 36);
            buttonSeeLog.TabIndex = 16;
            buttonSeeLog.Text = "See Log";
            buttonSeeLog.UseVisualStyleBackColor = false;
            buttonSeeLog.Visible = false;
            buttonSeeLog.Click += buttonSeeLog_click;
            // 
            // buttonContinue
            // 
            buttonContinue.AutoSize = true;
            buttonContinue.BackColor = Color.SteelBlue;
            buttonContinue.FlatAppearance.BorderSize = 0;
            buttonContinue.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
            buttonContinue.FlatAppearance.MouseOverBackColor = Color.SteelBlue;
            buttonContinue.FlatStyle = FlatStyle.Popup;
            buttonContinue.Font = new Font("Arial Unicode MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonContinue.ForeColor = SystemColors.ButtonHighlight;
            buttonContinue.Location = new Point(73, 193);
            buttonContinue.Name = "buttonContinue";
            buttonContinue.Size = new Size(108, 36);
            buttonContinue.TabIndex = 13;
            buttonContinue.Text = "Continue";
            buttonContinue.UseVisualStyleBackColor = false;
            buttonContinue.Visible = false;
            buttonContinue.Click += buttonContinue_Click;
            // 
            // labelProcess
            // 
            labelProcess.AutoSize = true;
            labelProcess.ForeColor = Color.Navy;
            labelProcess.Location = new Point(24, 50);
            labelProcess.Name = "labelProcess";
            labelProcess.Size = new Size(64, 15);
            labelProcess.TabIndex = 13;
            labelProcess.Text = "Processing";
            // 
            // labelProcessingFile
            // 
            labelProcessingFile.BorderStyle = BorderStyle.None;
            labelProcessingFile.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelProcessingFile.ForeColor = Color.Navy;
            labelProcessingFile.Location = new Point(27, 3);
            labelProcessingFile.Name = "labelProcessingFile";
            labelProcessingFile.Size = new Size(225, 18);
            labelProcessingFile.TabIndex = 12;
            labelProcessingFile.Text = "Processing the file";
            labelProcessingFile.Visible = false;
            // 
            // fileProcessing
            // 
            fileProcessing.BackColor = Color.LightSkyBlue;
            fileProcessing.BorderStyle = BorderStyle.None;
            fileProcessing.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            fileProcessing.ForeColor = SystemColors.InfoText;
            fileProcessing.Location = new Point(24, 22);
            fileProcessing.Name = "fileProcessing";
            fileProcessing.Size = new Size(340, 22);
            fileProcessing.TabIndex = 10;
            fileProcessing.TextAlign = HorizontalAlignment.Center;
            fileProcessing.Visible = false;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(24, 68);
            progressBar.Maximum = 0;
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(340, 40);
            progressBar.Step = 1;
            progressBar.TabIndex = 14;
            progressBar.Visible = false;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.ForeColor = Color.Navy;
            textBox2.Location = new Point(67, 14);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(81, 22);
            textBox2.TabIndex = 11;
            textBox2.Text = "Select files";
            // 
            // buttonStart
            // 
            buttonStart.BackColor = Color.LightSkyBlue;
            buttonStart.FlatAppearance.BorderSize = 0;
            buttonStart.FlatStyle = FlatStyle.Popup;
            buttonStart.Font = new Font("Arial Unicode MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonStart.ForeColor = SystemColors.ButtonHighlight;
            buttonStart.Location = new Point(141, 124);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(108, 32);
            buttonStart.TabIndex = 7;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = false;
            buttonStart.Visible = false;
            buttonStart.Click += buttonStart_Click;
            // 
            // listBox
            // 
            listBox.BorderStyle = BorderStyle.FixedSingle;
            listBox.FormattingEnabled = true;
            listBox.ItemHeight = 15;
            listBox.Location = new Point(67, 61);
            listBox.Name = "listBox";
            listBox.Size = new Size(390, 47);
            listBox.TabIndex = 6;
            listBox.Visible = false;
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.AliceBlue;
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonCancel.FlatStyle = FlatStyle.Popup;
            buttonCancel.Font = new Font("Arial Unicode MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCancel.ForeColor = SystemColors.AppWorkspace;
            buttonCancel.Location = new Point(274, 124);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(108, 32);
            buttonCancel.TabIndex = 13;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Visible = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(title);
            panel1.Location = new Point(2, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 86);
            panel1.TabIndex = 4;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.CausesValidation = false;
            label2.Font = new Font("Arial Unicode MS", 12F, FontStyle.Italic, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(256, 50);
            label2.Name = "label2";
            label2.Size = new Size(279, 21);
            label2.TabIndex = 4;
            label2.Text = "Easily extract information from text files";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(888, 577);
            Controls.Add(splitContainer1);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "FileToDB Connector";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonUpload;
        private OpenFileDialog openFileDialog1;
        private Label title;
        private SplitContainer splitContainer1;
        private PictureBox pictureBox1;
        private ListBox listBox;
        private Button buttonStart;
        private Panel panel1;
        private Label label2;
        private TextBox textBox2;
        private Panel panel2;
        private TextBox labelProcessingFile;
        private TextBox fileProcessing;
        private Label labelProcess;
        private ProgressBar progressBar;
        private Button buttonContinue;
        private TextBox general;
        private Button buttonSeeLog;
        private Label labelAlerts;
        private TextBox alerts;
        private Label percent;
        private Label regProcessing;
        private Button buttonCancel;
    }
}
