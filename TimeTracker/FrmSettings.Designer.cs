namespace TimeTracker
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.TxtSeconds = new System.Windows.Forms.TextBox();
            this.LblHours = new System.Windows.Forms.Label();
            this.TxtMinutes = new System.Windows.Forms.TextBox();
            this.TxtHours = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtSeconds
            // 
            this.TxtSeconds.Enabled = false;
            this.TxtSeconds.Location = new System.Drawing.Point(150, 10);
            this.TxtSeconds.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtSeconds.Name = "TxtSeconds";
            this.TxtSeconds.Size = new System.Drawing.Size(80, 22);
            this.TxtSeconds.TabIndex = 9;
            this.TxtSeconds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtSeconds.TextChanged += new System.EventHandler(this.TxtSeconds_TextChanged);
            // 
            // LblHours
            // 
            this.LblHours.AutoSize = true;
            this.LblHours.Location = new System.Drawing.Point(10, 10);
            this.LblHours.Name = "LblHours";
            this.LblHours.Size = new System.Drawing.Size(140, 17);
            this.LblHours.TabIndex = 8;
            this.LblHours.Text = "Interval (in seconds):";
            // 
            // TxtMinutes
            // 
            this.TxtMinutes.Location = new System.Drawing.Point(260, 10);
            this.TxtMinutes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtMinutes.Name = "TxtMinutes";
            this.TxtMinutes.Size = new System.Drawing.Size(80, 22);
            this.TxtMinutes.TabIndex = 10;
            this.TxtMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtMinutes.TextChanged += new System.EventHandler(this.TxtMinutes_TextChanged);
            // 
            // TxtHours
            // 
            this.TxtHours.Enabled = false;
            this.TxtHours.Location = new System.Drawing.Point(420, 10);
            this.TxtHours.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtHours.Name = "TxtHours";
            this.TxtHours.Size = new System.Drawing.Size(80, 22);
            this.TxtHours.TabIndex = 11;
            this.TxtHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(240, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "=";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(350, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "minutes =";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(510, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "hours";
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(490, 60);
            this.BtnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(60, 23);
            this.BtnSave.TabIndex = 15;
            this.BtnSave.Text = "&Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 90);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtHours);
            this.Controls.Add(this.TxtMinutes);
            this.Controls.Add(this.TxtSeconds);
            this.Controls.Add(this.LblHours);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSettings";
            this.ShowIcon = false;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.FrmSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtSeconds;
        private System.Windows.Forms.Label LblHours;
        private System.Windows.Forms.TextBox TxtMinutes;
        private System.Windows.Forms.TextBox TxtHours;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnSave;
    }
}