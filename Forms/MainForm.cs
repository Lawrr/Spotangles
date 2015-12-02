using System;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace Spotangles {
    public partial class MainForm : Form {

		private int numChecked = 0;
		private System.Timers.Timer timer;
		private AlertForm alertForm = null;
		private string updatedTime = "";

		public MainForm() {
			InitializeComponent();

			this.CenterToScreen();

			timer = new System.Timers.Timer(1000 *  5);
			timer.Elapsed += new ElapsedEventHandler(OnClassCheck);

			this.StatusLabel.Text = "Status: Idle";
			this.StopButton.Enabled = false;
		}

        public void Open() {
            Show();
            BringToFront();
            Activate();
        }

		private void OnClassCheck(object sender, EventArgs e) {
			if (alertForm == null) {
				this.Invoke(new Action(CheckClasses));
			}
		}

		private void CheckClasses() {
			string[] availableClasses = ClassUtilHandler.GetAvailableClasses(Program.TrackedClasses);
			updatedTime = ClassUtilHandler.GetUpdatedTime();
			this.UpdateLabel.Text = "Data is correct as at: " + updatedTime;
			numChecked++;
			this.StatusLabel.Text = "Status: Started [Checked " + this.numChecked + " times]";
			if (availableClasses.Length > 0) {
				alertForm = new AlertForm(availableClasses);
				alertForm.ShowDialog();
				alertForm = null;
			}
		}

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            Hide();
            e.Cancel = true;
        }

		private void SettingsButton_Click(object sender, EventArgs e) {
			SettingsForm settingsForm = new SettingsForm();
			settingsForm.ShowDialog();
		}

		private void StartButton_Click(object sender, EventArgs e) {
			this.StatusLabel.Text = "Status: Started [Checked " + this.numChecked + " times]";
			this.SettingsButton.Enabled = false;
			this.StopButton.Enabled = true;
			this.StartButton.Enabled = false;
			CheckClasses();
			timer.Start();
		}

		private void StopButton_Click(object sender, EventArgs e) {
			this.StatusLabel.Text = "Status: Idle";
			this.numChecked = 0;
			this.SettingsButton.Enabled = true;
			this.StartButton.Enabled = true;
			this.StopButton.Enabled = false;
			timer.Stop();
		}
	}
}
