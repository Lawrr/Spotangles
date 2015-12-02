using System;
using System.Windows.Forms;

namespace Spotangles {
    public partial class SettingsForm : Form {

		public SettingsForm() {
			InitializeComponent();

			CenterToScreen();

			foreach (string trackedClass in Program.TrackedClasses) {
				TrackBox.Items.Add(trackedClass);
			}

			RemoveButton.Enabled = false;
		}

		private void CloseButton_Click(object sender, EventArgs e) {
			Close();
		}

		private void SearchButton_Click(object sender, EventArgs e) {
			ClassSearchForm classCheckerForm = new ClassSearchForm(this, this.CourseInputBox.Text);
			classCheckerForm.ShowDialog();
		}

		public void AddClass(string classString) {
			TrackBox.Items.Add(classString);
		}

		private void TrackBox_SelectedIndexChanged(object sender, System.EventArgs e) {
			// Enable button
			RemoveButton.Enabled = true;
		}

		private void RemoveButton_Click(object sender, EventArgs e) {
			if (this.TrackBox.SelectedItems.Count == 1) {
				Program.TrackedClasses.RemoveAt(TrackBox.SelectedIndex);
				TrackBox.Items.RemoveAt(TrackBox.SelectedIndex);
			}
			RemoveButton.Enabled = false;
		}

	}
}
