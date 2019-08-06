using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TimeTracker
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(Application.StartupPath));
            //MessageBox.Show(Path.GetDirectoryName(Application.ExecutablePath));

            // Load settings
            TTSetting t;
            TTSettings tts = new TTSettings();

            t = tts.GetTTSettings();

            TxtEmployeeId.Text = t.EmployeeId;
            TTStatic.ttPathToDataLocal = t.PathToDataLocal;
            TTStatic.ttPathToDataCentral = t.PathToDataCentral;
            TTStatic.ttAppPath = Application.StartupPath;
            TimTimer.Interval = t.Interval;

            DteDate.MinDate = DateTime.Now.AddDays(-42);

            // Position form
            this.Left = t.Left;
            this.Top = t.Top;

            //Call methid to create WBS buttons (and hidden text fields) from WBS.TXT file
            CreateWBSButtons("WBS");

            //Get week number based on date
            TxtWeek.Text=TTStatic.GetWeekNumber(DteDate.Text).ToString();

            //Get version, interval, hours per day and week for top of window
            GetThisText();
        }

        private void CreateWBSButtons(string show)
        {
            //Variables for positioning buttons
            int left = 5;
            int top = 55;
            int width = 146;
            int height = 20;
            int hSpace = 3;
            int vSpace = 3;
            int hButtons = 4; //Number of buttons horizontally
            int vButtons = 4; //Number of buttons vertically
            int buttonIndex = 0;

            string line;
            string WBS;
            string WBSDescription;

            //Create arrays for WBS numbers
            Button[] buttonArray = new Button[hButtons * vButtons];
            TextBox[] textBoxArray = new TextBox[hButtons * vButtons];
            ToolTip[] toolTipArray = new ToolTip[hButtons * vButtons];

            //Create instance of TimeTracker to access methods
            TTTimeTracker t = new TTTimeTracker();

            //Open WBS.TXT filr for reading
            StreamReader file = new StreamReader(TTStatic.ttAppPath + "\\WBS.txt");

            //Create buttons (horizontal x vertical)
            for (int i = 0; i < vButtons; i++)
            {
                for (int j = 0; j < hButtons; j++)
                {
                    line = file.ReadLine();

                    if (line != null && line.Length > 0)
                    {
                        WBS = TTStatic.GetDelimitedFieldData(line, 1, ",");
                        WBSDescription = TTStatic.GetDelimitedFieldData(line, 2, ",");

                        //Hidden textbox array to use for WBS description
                        textBoxArray[buttonIndex] = new TextBox();
                        textBoxArray[buttonIndex].Name = "TxtWBSDescription_" + WBS;
                        textBoxArray[buttonIndex].Text = WBSDescription;
                        textBoxArray[buttonIndex].Visible = false;

                        //Button array to use for WBS
                        buttonArray[buttonIndex] = new Button();
                        buttonArray[buttonIndex].Name = "BtnWBS_" + WBS;
                        buttonArray[buttonIndex].Click += new EventHandler(buttonArray_Click);

                        buttonArray[buttonIndex].Size = new Size(width, height);
                        buttonArray[buttonIndex].Location = new Point(left + j * (width + vSpace), top + i * (height + hSpace));

                        buttonArray[buttonIndex].Text = WBS;
                        toolTipArray[buttonIndex] = new ToolTip();
                        toolTipArray[buttonIndex].SetToolTip(buttonArray[buttonIndex], WBSDescription);

                        //Add buttons and textboxes to Controls collection
                        this.Controls.Add(buttonArray[buttonIndex]);
                        this.Controls.Add(textBoxArray[buttonIndex]);
                        buttonIndex += 1;
                    }
                }
            }

            file.Close();

            //Call this to show WBS descriptions instead of numbers on buttons
            this.LblWBS_Click(this, null);
        }




        void buttonArray_Click(object sender, EventArgs e)
        {
            //Use sender to identify which button in array was pressed
            var current = sender as Button;

            //Use name of button to get WBS number: TxtWBS_xxxxxxxx where xxxxxxxx starts on position 7
            TxtWBS.Text = current.Name.Substring(7);

            //Find corresponding WBS description
            foreach (Control c in this.Controls)
            {
                if (c.Name == "TxtWBSDescription_" + current.Name.Substring(7))
                {
                    TxtWBSDescription.Text = c.Text;
                }
            }

            TxtComment.Focus();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string date;
            int weeknumber;
            string line;
            string errMessage = "";

            //Save position of form
            SavePosition();

            //Update window header information
            GetThisText();


            //Validate WBS Format
            string WBSpattern = @"^I-([0-9]{6})\.([0-9]{2})\.([0-2]{2})\.([0-8]{2})$";
            Match match = Regex.Match(TxtWBS.Text, WBSpattern, RegexOptions.IgnoreCase);
            if (match.Success)
                /*proceed*/;
            else
            { errMessage += "WBS: Invalid"; errMessage += Environment.NewLine; }
                

            //Only allows numeric values into Hours field
            Match match2 = Regex.Match(TxtHours.Text, "^[0-9].?[0-9]*$");    
            if (match2.Success)
                /*proceed*/;
            else 
            { errMessage += "Invalid Hours Entry"; errMessage += Environment.NewLine; }


            //Check sapbatch.txt file to see if WBS exists
            string filePath = @"C:\Users\usjafr00\source\repos\TimeTracker\TimeTracker\bin\Debug\sapbatch.txt";
            string[] wbslist = File.ReadAllLines(filePath);
            bool wbsExists = Array.Exists(wbslist, element => element == TxtWBS.Text);
            if (wbsExists)
                /*proceed*/;
            else
                errMessage += "This WBS does not exist" + Environment.NewLine;



            //Show Error upon empty fields
            if (TxtEmployeeId.Text == "" ) { errMessage += "Employee ID can't be empty"; errMessage += Environment.NewLine; }
            if (TxtWBS.Text == "") { errMessage += "WBS can't be empty"; errMessage += Environment.NewLine; }
            if (DteDate.Text == "") { errMessage += "Date can't be empty"; errMessage += Environment.NewLine; }
            if (TxtHours.Text == "") { errMessage += "Hours can't be empty"; }
            if (TxtHours.Text == "0" || TxtHours.Text == "0.0") { errMessage += "Hours can't be 0"; }

            if (errMessage != "") { MessageBox.Show(errMessage); return; }

            //Convert date to YYYYMMDD for filename
            date = TTStatic.ConvertDate(DteDate.Text);

            //Get weeknumber for filename
            weeknumber = TTStatic.GetWeekNumber(DteDate.Text);

            //Craete the line to save in the file
            line = TxtEmployeeId.Text + "," + date + "," + TxtWBS.Text + "," + TxtWBSDescription.Text + "," + TxtHours.Text + "," + TxtComment.Text;

            //Create file or add line to file
            using (StreamWriter file = new StreamWriter(TTStatic.ttPathToDataLocal + "\\" + this.TxtEmployeeId.Text + "_" + weeknumber + "_" + date + ".txt", true))
            {
                file.WriteLine(line);
            }

            TxtHours.Text = "";
            TxtWBS.Text = "";
            TxtWBSDescription.Text = "";
            TxtComment.Text = "";

            //Update window header information
            GetThisText();
        }

        private void BtnHide_Click(object sender, EventArgs e)
        {
            //Save position of form
            SavePosition();

            //Update window header information
            GetThisText();

            //Hide form and enable timer to show on top again after selected interval
            this.TopMost = false;
            this.Hide();
            TimTimer.Enabled = true;
        }

        private void TimTimer_Tick(object sender, EventArgs e)
        {
            //Show form after interval, TopMost will bring to front of all other windows
            TimTimer.Enabled = false;
            this.Show();
            this.TopMost = true;
        }

        private void Btn05_Click(object sender, EventArgs e)
        {
            //Add time to hours worked on WBS
            if (TxtHours.Text == "") { TxtHours.Text = "0"; }
            TxtHours.Text = (double.Parse(TxtHours.Text) + 0.5).ToString();
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            //Add time to hours worked on WBS
            if (TxtHours.Text == "") { TxtHours.Text = "0"; }
            TxtHours.Text = (double.Parse(TxtHours.Text) + 1).ToString();
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            //Add time to hours worked on WBS
            if (TxtHours.Text == "") { TxtHours.Text = "0"; }
            TxtHours.Text = (double.Parse(TxtHours.Text) + 2).ToString();
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            //Add time to hours worked on WBS
            if (TxtHours.Text == "") { TxtHours.Text = "0"; }
            TxtHours.Text = (double.Parse(TxtHours.Text) + 4).ToString();
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            //Add time to hours worked on WBS
            if (TxtHours.Text == "") { TxtHours.Text = "0"; }
            TxtHours.Text = (double.Parse(TxtHours.Text) + 8).ToString();
        }

        public void SavePosition()
        {
            //Save position of form to TTSETTINGS for next time it opens
            TTSettings t = new TTSettings();
            t.SetTTSettingsLocation(this);
        }

        public void SaveEmployeeId()
        {
            //Save employee id to TTSETTINGS for next time it opens
            TTSettings t = new TTSettings();
            t.SetTTSettingsEmployeeId(TxtEmployeeId.Text);
        }

        public string GetPopupInterval()
        {
            double temp;
            string interval = "";

            //Get interval to show in window header, interval is set in milliseconds = 10,000 per second
            if (TimTimer.Interval / 1000 < 60)
            {
                temp = (TimTimer.Interval / 1000);
                interval = (TimTimer.Interval / 1000).ToString() + " seconds";
            }
            else if (TimTimer.Interval / 1000 < 3600)
            {
                temp = ((double)TimTimer.Interval / 1000 / 60);
                temp = Math.Round(temp, 1);
                interval = temp.ToString() + " minutes";
            }
            else if (TimTimer.Interval / 1000 >= 3600)
            {
                temp = ((double)TimTimer.Interval / 1000 / 60 / 60);
                temp = Math.Round(temp, 1);
                interval = temp.ToString() + " hours";
            }
            else
            {
                interval = "";
            }

            return interval;
        }

        public void GetThisText()
        {
            //
            double hoursDate = 0.0;
            double hoursWeek = 0.0;
            string interval = "";

            TTTimeTracker tt = new TTTimeTracker();

            //Calculate hours for selected date (in date picker control) and corresponding week
            hoursDate = tt.CalculateSumHoursForDate(TxtEmployeeId.Text, DteDate.Text);
            hoursWeek = tt.CalculateSumHoursForWeek(TxtEmployeeId.Text, DteDate.Text);

            //Get popup interval
            interval = GetPopupInterval();

            //Update windows header
            this.Text = "TimeTracker v" + TTStatic.ttVersion + " |  Popup: " + interval + " | " + DteDate.Text + ": " + hoursDate + " hours | Week " + TxtWeek.Text + ": " + hoursWeek + " hours";
        }

        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            //Intended for opening the "per employee and date files" but can of course open any text file (opens with NOTEPAD.EXE so won't work with non-text files) 
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = TTStatic.ttPathToDataLocal;
            ofd.DefaultExt = ".txt";
            ofd.Filter = "Text Files (*.txt)|*.txt" + "|" + "All Files (*.*)|*.*";

            DialogResult result = ofd.ShowDialog();

            if (result == DialogResult.OK)
            {
                var filePath = ofd.FileName;

                using (FileStream fs = File.Open(filePath, FileMode.Open))
                {
                    Process.Start("notepad.exe", filePath);
                }
            }
        }

        private void LblWBS_Click(object sender, EventArgs e)
        {
            string line;
            string wbs;
            string description;

            //Will switch the text of WBS buttons between WBS number and WBS description
            foreach (Button btn in this.Controls.OfType<Button>())
            { 
                if (btn.Name.IndexOf("BtnWBS_") >= 0)
                {
                    StreamReader file = new StreamReader(TTStatic.ttAppPath + "\\WBS.txt");

                    while ((line = file.ReadLine()) != null)
                    {
                        wbs = TTStatic.GetDelimitedFieldData(line, 1, ",");
                        description = TTStatic.GetDelimitedFieldData(line, 2, ",");

                        if (wbs == btn.Text)
                        {
                            btn.Text = description;
                        }
                        else if (description == btn.Text)
                        {
                            btn.Text = wbs;
                        }
                    }

                    file.Close();
                }
            }
        }

        private void DteDate_ValueChanged(object sender, EventArgs e)
        {
            //Change week number field if date changes
            TxtWeek.Text = TTStatic.GetWeekNumber(DteDate.Text).ToString();

            //Update windows header
            GetThisText();
        }

        private void TxtPPSAP_Click(object sender, EventArgs e)
        {
            string file;

            //Call function to calculate PlanPort and SAP hours for week of chosen date, adjusting SAP hours to 40 hours proportion
            TTTimeTracker t = new TTTimeTracker();

            file = t.CalculateSumHoursForWeekPPSAP(TxtEmployeeId.Text, DteDate.Text);

            if (file == "NO_DATA")
            {
                MessageBox.Show("No data found!");
            }
            else if (file == "NOT_40")
            {
                MessageBox.Show("40 hours or more must be booked before a weekly file can be created!");
            }
            else
            {
                using (FileStream fs = File.Open(file, FileMode.Open))
                {
                    Process.Start("notepad.exe", file);
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            //Close application after saving position of form and employee id TTSETTINGS.JSON
            SavePosition();
            SaveEmployeeId();

            Application.Exit();
        }

        private void LblHours_Click(object sender, EventArgs e)
        {
            //Reset hours to 0
            TxtHours.Text = "0";
        }

        private void LblEmployeeId_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", TTStatic.ttAppPath + "\\ttsettings.txt");
        }

        private void BtnTimer_Click(object sender, EventArgs e)
        {
            //Create settings form object
            frmSettings f = new frmSettings();

            //Show settings form as modal (has to be closed before application continues)
            f.ShowDialog();

            //Update settings based on form
            TTSettings t = new TTSettings();

            //update Timer and refresh window header
            TimTimer.Interval = t.GetTTSettingsInterval();
            GetThisText();
        }

        
        private void TxtWBSs_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", TTStatic.ttAppPath + "\\wbs.txt");
        }

        private void TxtWeek_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtEmployeeId_TextChanged(object sender, EventArgs e)
        {

        }
        
        

    }
}
