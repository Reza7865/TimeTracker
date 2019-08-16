using System;
using System.Windows.Forms;

namespace TimeTracker
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //Save interval if seconds field has a valid value
            try
            {
                if (TxtSeconds.Text != "")
                {
                    TTSettings t = new TTSettings();

                    t.SetTTSettingsInterval(Int32.Parse(TxtSeconds.Text) * 1000);
                }
            }

            catch
            {
                this.Close();
            }

            this.Close();
        }

        private void TxtSeconds_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            //Set seconds to current interval when loading settings form
            TTSettings t = new TTSettings();

            TxtSeconds.Text = (t.GetTTSettingsInterval() / 1000).ToString();
        }

        private void TxtMinutes_TextChanged(object sender, EventArgs e)
        {
            //Update minutes and hours as seconds field changes, if valid data entered
            try
            {
                TxtSeconds.Text = Math.Round((double.Parse(TxtMinutes.Text) * 60), 1).ToString();
                TxtHours.Text = Math.Round((double.Parse(TxtMinutes.Text) / 60), 2).ToString();
            }
            catch
            {
                TxtMinutes.Text = "";
                TxtHours.Text = "";
            }

        }
    }
}
