namespace TimeTracker
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.BtnHide = new System.Windows.Forms.Button();
            this.TimTimer = new System.Windows.Forms.Timer(this.components);
            this.TxtEmployeeId = new System.Windows.Forms.TextBox();
            this.LblEmployeeId = new System.Windows.Forms.Label();
            this.LblHours = new System.Windows.Forms.Label();
            this.TxtHours = new System.Windows.Forms.TextBox();
            this.Btn05 = new System.Windows.Forms.Button();
            this.Btn1 = new System.Windows.Forms.Button();
            this.TxtWBS = new System.Windows.Forms.TextBox();
            this.LblWBS = new System.Windows.Forms.Label();
            this.Btn4 = new System.Windows.Forms.Button();
            this.Btn8 = new System.Windows.Forms.Button();
            this.Btn2 = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtComment = new System.Windows.Forms.TextBox();
            this.LblComment = new System.Windows.Forms.Label();
            this.BtnOpenFile = new System.Windows.Forms.Button();
            this.DteDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtWeek = new System.Windows.Forms.TextBox();
            this.TxtPPSAP = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.TxtWBSDescription = new System.Windows.Forms.TextBox();
            this.BtnTimer = new System.Windows.Forms.Button();
            this.TxtWBSs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnHide
            // 
            this.BtnHide.Location = new System.Drawing.Point(551, 35);
            this.BtnHide.Margin = new System.Windows.Forms.Padding(2);
            this.BtnHide.Name = "BtnHide";
            this.BtnHide.Size = new System.Drawing.Size(45, 19);
            this.BtnHide.TabIndex = 14;
            this.BtnHide.Text = "&Hide";
            this.BtnHide.UseVisualStyleBackColor = true;
            this.BtnHide.Click += new System.EventHandler(this.BtnHide_Click);
            // 
            // TimTimer
            // 
            this.TimTimer.Interval = 10000;
            this.TimTimer.Tick += new System.EventHandler(this.TimTimer_Tick);
            // 
            // TxtEmployeeId
            // 
            this.TxtEmployeeId.Enabled = false;
            this.TxtEmployeeId.Location = new System.Drawing.Point(51, 8);
            this.TxtEmployeeId.Margin = new System.Windows.Forms.Padding(2);
            this.TxtEmployeeId.Name = "TxtEmployeeId";
            this.TxtEmployeeId.Size = new System.Drawing.Size(54, 20);
            this.TxtEmployeeId.TabIndex = 2;
            this.TxtEmployeeId.Text = "074164";
            this.TxtEmployeeId.TextChanged += new System.EventHandler(this.TxtEmployeeId_TextChanged);
            // 
            // LblEmployeeId
            // 
            this.LblEmployeeId.AutoSize = true;
            this.LblEmployeeId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblEmployeeId.Location = new System.Drawing.Point(3, 8);
            this.LblEmployeeId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblEmployeeId.Name = "LblEmployeeId";
            this.LblEmployeeId.Size = new System.Drawing.Size(47, 15);
            this.LblEmployeeId.TabIndex = 2;
            this.LblEmployeeId.Text = "Emp ID:";
            this.LblEmployeeId.Click += new System.EventHandler(this.LblEmployeeId_Click);
            // 
            // LblHours
            // 
            this.LblHours.AutoSize = true;
            this.LblHours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblHours.Location = new System.Drawing.Point(234, 32);
            this.LblHours.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblHours.Name = "LblHours";
            this.LblHours.Size = new System.Drawing.Size(40, 15);
            this.LblHours.TabIndex = 4;
            this.LblHours.Text = "Hours:";
            this.LblHours.Click += new System.EventHandler(this.LblHours_Click);
            // 
            // TxtHours
            // 
            this.TxtHours.Location = new System.Drawing.Point(278, 32);
            this.TxtHours.Margin = new System.Windows.Forms.Padding(2);
            this.TxtHours.Name = "TxtHours";
            this.TxtHours.Size = new System.Drawing.Size(27, 20);
            this.TxtHours.TabIndex = 7;
            this.TxtHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Btn05
            // 
            this.Btn05.Location = new System.Drawing.Point(310, 32);
            this.Btn05.Margin = new System.Windows.Forms.Padding(2);
            this.Btn05.Name = "Btn05";
            this.Btn05.Size = new System.Drawing.Size(27, 19);
            this.Btn05.TabIndex = 8;
            this.Btn05.Text = ".5";
            this.Btn05.UseVisualStyleBackColor = true;
            this.Btn05.Click += new System.EventHandler(this.Btn05_Click);
            // 
            // Btn1
            // 
            this.Btn1.Location = new System.Drawing.Point(340, 32);
            this.Btn1.Margin = new System.Windows.Forms.Padding(2);
            this.Btn1.Name = "Btn1";
            this.Btn1.Size = new System.Drawing.Size(27, 19);
            this.Btn1.TabIndex = 9;
            this.Btn1.Text = "1";
            this.Btn1.UseVisualStyleBackColor = true;
            this.Btn1.Click += new System.EventHandler(this.Btn1_Click);
            // 
            // TxtWBS
            // 
            this.TxtWBS.Location = new System.Drawing.Point(146, 8);
            this.TxtWBS.Margin = new System.Windows.Forms.Padding(2);
            this.TxtWBS.Name = "TxtWBS";
            this.TxtWBS.Size = new System.Drawing.Size(103, 20);
            this.TxtWBS.TabIndex = 3;
            // 
            // LblWBS
            // 
            this.LblWBS.AutoSize = true;
            this.LblWBS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblWBS.Location = new System.Drawing.Point(109, 8);
            this.LblWBS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblWBS.Name = "LblWBS";
            this.LblWBS.Size = new System.Drawing.Size(37, 15);
            this.LblWBS.TabIndex = 11;
            this.LblWBS.Text = "WBS:";
            this.LblWBS.Click += new System.EventHandler(this.LblWBS_Click);
            // 
            // Btn4
            // 
            this.Btn4.Location = new System.Drawing.Point(401, 32);
            this.Btn4.Margin = new System.Windows.Forms.Padding(2);
            this.Btn4.Name = "Btn4";
            this.Btn4.Size = new System.Drawing.Size(27, 19);
            this.Btn4.TabIndex = 11;
            this.Btn4.Text = "4";
            this.Btn4.UseVisualStyleBackColor = true;
            this.Btn4.Click += new System.EventHandler(this.Btn4_Click);
            // 
            // Btn8
            // 
            this.Btn8.Location = new System.Drawing.Point(432, 32);
            this.Btn8.Margin = new System.Windows.Forms.Padding(2);
            this.Btn8.Name = "Btn8";
            this.Btn8.Size = new System.Drawing.Size(27, 19);
            this.Btn8.TabIndex = 12;
            this.Btn8.Text = "8";
            this.Btn8.UseVisualStyleBackColor = true;
            this.Btn8.Click += new System.EventHandler(this.Btn8_Click);
            // 
            // Btn2
            // 
            this.Btn2.Location = new System.Drawing.Point(370, 32);
            this.Btn2.Margin = new System.Windows.Forms.Padding(2);
            this.Btn2.Name = "Btn2";
            this.Btn2.Size = new System.Drawing.Size(27, 19);
            this.Btn2.TabIndex = 10;
            this.Btn2.Text = "2";
            this.Btn2.UseVisualStyleBackColor = true;
            this.Btn2.Click += new System.EventHandler(this.Btn2_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(502, 35);
            this.BtnSave.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(45, 19);
            this.BtnSave.TabIndex = 13;
            this.BtnSave.Text = "&Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(11, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "Date:";
            // 
            // TxtComment
            // 
            this.TxtComment.Location = new System.Drawing.Point(456, 8);
            this.TxtComment.Margin = new System.Windows.Forms.Padding(2);
            this.TxtComment.Name = "TxtComment";
            this.TxtComment.Size = new System.Drawing.Size(218, 20);
            this.TxtComment.TabIndex = 1;
            // 
            // LblComment
            // 
            this.LblComment.AutoSize = true;
            this.LblComment.Location = new System.Drawing.Point(405, 10);
            this.LblComment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblComment.Name = "LblComment";
            this.LblComment.Size = new System.Drawing.Size(54, 13);
            this.LblComment.TabIndex = 20;
            this.LblComment.Text = "Comment:";
            // 
            // BtnOpenFile
            // 
            this.BtnOpenFile.Location = new System.Drawing.Point(620, 35);
            this.BtnOpenFile.Margin = new System.Windows.Forms.Padding(2);
            this.BtnOpenFile.Name = "BtnOpenFile";
            this.BtnOpenFile.Size = new System.Drawing.Size(45, 19);
            this.BtnOpenFile.TabIndex = 15;
            this.BtnOpenFile.Text = "Files";
            this.BtnOpenFile.UseVisualStyleBackColor = true;
            this.BtnOpenFile.Click += new System.EventHandler(this.BtnOpenFile_Click);
            // 
            // DteDate
            // 
            this.DteDate.CustomFormat = "MM/dd/yyyy";
            this.DteDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DteDate.Location = new System.Drawing.Point(50, 32);
            this.DteDate.Margin = new System.Windows.Forms.Padding(2);
            this.DteDate.Name = "DteDate";
            this.DteDate.Size = new System.Drawing.Size(84, 20);
            this.DteDate.TabIndex = 5;
            this.DteDate.ValueChanged += new System.EventHandler(this.DteDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Week:";
            // 
            // TxtWeek
            // 
            this.TxtWeek.Enabled = false;
            this.TxtWeek.Location = new System.Drawing.Point(172, 32);
            this.TxtWeek.Margin = new System.Windows.Forms.Padding(2);
            this.TxtWeek.Name = "TxtWeek";
            this.TxtWeek.Size = new System.Drawing.Size(23, 20);
            this.TxtWeek.TabIndex = 6;
            this.TxtWeek.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtWeek.TextChanged += new System.EventHandler(this.TxtWeek_TextChanged);
            // 
            // TxtPPSAP
            // 
            this.TxtPPSAP.Location = new System.Drawing.Point(620, 58);
            this.TxtPPSAP.Margin = new System.Windows.Forms.Padding(2);
            this.TxtPPSAP.Name = "TxtPPSAP";
            this.TxtPPSAP.Size = new System.Drawing.Size(45, 19);
            this.TxtPPSAP.TabIndex = 16;
            this.TxtPPSAP.Text = "Week";
            this.TxtPPSAP.UseVisualStyleBackColor = true;
            this.TxtPPSAP.Click += new System.EventHandler(this.TxtPPSAP_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(620, 127);
            this.BtnClose.Margin = new System.Windows.Forms.Padding(2);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(45, 19);
            this.BtnClose.TabIndex = 19;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // TxtWBSDescription
            // 
            this.TxtWBSDescription.Location = new System.Drawing.Point(253, 8);
            this.TxtWBSDescription.Margin = new System.Windows.Forms.Padding(2);
            this.TxtWBSDescription.Name = "TxtWBSDescription";
            this.TxtWBSDescription.Size = new System.Drawing.Size(148, 20);
            this.TxtWBSDescription.TabIndex = 4;
            // 
            // BtnTimer
            // 
            this.BtnTimer.Location = new System.Drawing.Point(620, 104);
            this.BtnTimer.Margin = new System.Windows.Forms.Padding(2);
            this.BtnTimer.Name = "BtnTimer";
            this.BtnTimer.Size = new System.Drawing.Size(45, 19);
            this.BtnTimer.TabIndex = 18;
            this.BtnTimer.Text = "Timer";
            this.BtnTimer.UseVisualStyleBackColor = true;
            this.BtnTimer.Click += new System.EventHandler(this.BtnTimer_Click);
            // 
            // TxtWBSs
            // 
            this.TxtWBSs.Location = new System.Drawing.Point(620, 81);
            this.TxtWBSs.Margin = new System.Windows.Forms.Padding(2);
            this.TxtWBSs.Name = "TxtWBSs";
            this.TxtWBSs.Size = new System.Drawing.Size(45, 19);
            this.TxtWBSs.TabIndex = 17;
            this.TxtWBSs.Text = "WBSs";
            this.TxtWBSs.UseVisualStyleBackColor = true;
            this.TxtWBSs.Click += new System.EventHandler(this.TxtWBSs_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 167);
            this.Controls.Add(this.TxtWBSs);
            this.Controls.Add(this.BtnTimer);
            this.Controls.Add(this.TxtWBSDescription);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.TxtPPSAP);
            this.Controls.Add(this.TxtWeek);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DteDate);
            this.Controls.Add(this.BtnOpenFile);
            this.Controls.Add(this.TxtComment);
            this.Controls.Add(this.TxtWBS);
            this.Controls.Add(this.LblComment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.Btn2);
            this.Controls.Add(this.Btn8);
            this.Controls.Add(this.Btn4);
            this.Controls.Add(this.LblWBS);
            this.Controls.Add(this.TxtEmployeeId);
            this.Controls.Add(this.TxtHours);
            this.Controls.Add(this.Btn1);
            this.Controls.Add(this.Btn05);
            this.Controls.Add(this.LblHours);
            this.Controls.Add(this.LblEmployeeId);
            this.Controls.Add(this.BtnHide);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmMain";
            this.Text = "TimeTracker";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnHide;
        private System.Windows.Forms.Timer TimTimer;
        private System.Windows.Forms.Label LblEmployeeId;
        private System.Windows.Forms.Label LblHours;
        private System.Windows.Forms.TextBox TxtHours;
        private System.Windows.Forms.Button Btn05;
        private System.Windows.Forms.Button Btn1;
        private System.Windows.Forms.TextBox TxtWBS;
        private System.Windows.Forms.Label LblWBS;
        private System.Windows.Forms.Button Btn4;
        private System.Windows.Forms.Button Btn8;
        private System.Windows.Forms.Button Btn2;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtComment;
        private System.Windows.Forms.Label LblComment;
        private System.Windows.Forms.Button BtnOpenFile;
        private System.Windows.Forms.DateTimePicker DteDate;
        public System.Windows.Forms.TextBox TxtEmployeeId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtWeek;
        private System.Windows.Forms.Button TxtPPSAP;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.TextBox TxtWBSDescription;
        private System.Windows.Forms.Button BtnTimer;
        private System.Windows.Forms.Button TxtWBSs;
    }
}

