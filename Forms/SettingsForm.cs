using Spotangles;
using System;
using System.Windows.Forms;

namespace Spotangles {
    public partial class SettingsForm : Form {

		public SettingsForm() {
			InitializeComponent();

			CenterToScreen();

            // Set default semester
            SemesterComboBox.SelectedIndex = 0;

            // Add tracked classes
			foreach (ClassDetails trackedClass in Program.TrackedClasses) {
				TrackBox.Items.Add(trackedClass);
			}

            // Disable remove button
			RemoveButton.Enabled = false;
		}

		private void CloseButton_Click(object sender, EventArgs e) {
			Close();
		}

		private void SearchButton_Click(object sender, EventArgs e) {
			ClassSearchForm classCheckerForm = new ClassSearchForm(this, CourseInputBox.Text, SemesterExtensions.Parse(SemesterComboBox.SelectedItem.ToString()));
			classCheckerForm.ShowDialog();
		}

		public void AddClass(ClassDetails newClass) {
			TrackBox.Items.Add(newClass);
		}

		private void TrackBox_SelectedIndexChanged(object sender, System.EventArgs e) {
			// Enable button
			RemoveButton.Enabled = true;
		}

		private void RemoveButton_Click(object sender, EventArgs e) {
			if (TrackBox.SelectedItems.Count == 1) {
				Program.TrackedClasses.RemoveAt(TrackBox.SelectedIndex);
				TrackBox.Items.RemoveAt(TrackBox.SelectedIndex);
			}
			RemoveButton.Enabled = false;
		}

	}
}
