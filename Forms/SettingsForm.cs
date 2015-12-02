using System;
using System.Windows.Forms;

namespace Spotangles {
    public partial class SettingsForm : Form {
		public SettingsForm() {
			InitializeComponent();

			this.CenterToScreen();

			foreach (string trackedClass in Program.trackedClasses) {
				this.trackBox.Items.Add(trackedClass);
			}

			this.removeBTN.Enabled = false;
		}

		private void closeBTN_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void searchBTN_Click(object sender, EventArgs e) {
			ClassSearchForm classCheckerForm = new ClassSearchForm(this, this.courseInputBox.Text);
			classCheckerForm.ShowDialog();
		}

		public void AddClass(string classString) {
			this.trackBox.Items.Add(classString);
		}

		private void trackBox_SelectedIndexChanged(object sender, System.EventArgs e) {
			// Enable button
			this.removeBTN.Enabled = true;
		}

		private void removeBTN_Click(object sender, EventArgs e) {
			if (this.trackBox.SelectedItems.Count == 1) {
				Program.trackedClasses.RemoveAt(this.trackBox.SelectedIndex);
				this.trackBox.Items.RemoveAt(this.trackBox.SelectedIndex);
			}
			this.removeBTN.Enabled = false;
		}
	}
}
