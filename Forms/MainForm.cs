using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows.Forms;

namespace Spotangles {
    public partial class MainForm : Form {

		private int NumChecked = 0;
		private System.Timers.Timer Timer;
		private AlertForm AlertForm = null;
		private string UpdatedTime = "";

		public MainForm() {
			InitializeComponent();

			CenterToScreen();

			Timer = new System.Timers.Timer(1000 * 60 * 5);
			Timer.Elapsed += new ElapsedEventHandler(OnClassCheck);

			StatusLabel.Text = "Status: Idle";
			StopButton.Enabled = false;
		}

        public void Open() {
            Show();
            BringToFront();
            Activate();
        }

		private void OnClassCheck(object sender, EventArgs e) {
			if (AlertForm == null) {
				Invoke(new Action(CheckClasses));
			}
		}

		private void CheckClasses() {
			List<ClassDetails> availableClasses = ClassUtilHandler.GetAvailableClasses(Program.TrackedClasses);
			UpdatedTime = ClassUtilHandler.GetUpdatedTime();
			UpdateLabel.Text = "Data is correct as at: " + UpdatedTime;
			NumChecked++;
			StatusLabel.Text = "Status: Started [Checked " + NumChecked + " times]";
			if (availableClasses.Count > 0) {
				AlertForm = new AlertForm(availableClasses);
				AlertForm.ShowDialog();
				AlertForm = null;
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
			StatusLabel.Text = "Status: Started [Checked " + NumChecked + " times]";
			SettingsButton.Enabled = false;
			StopButton.Enabled = true;
			StartButton.Enabled = false;
			CheckClasses();
			Timer.Start();
		}

		private void StopButton_Click(object sender, EventArgs e) {
			StatusLabel.Text = "Status: Idle";
			NumChecked = 0;
			SettingsButton.Enabled = true;
			StartButton.Enabled = true;
			StopButton.Enabled = false;
			Timer.Stop();
		}
	}
}
