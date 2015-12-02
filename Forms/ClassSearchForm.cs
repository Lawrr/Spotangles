using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Spotangles {
	public partial class ClassSearchForm : Form {

		private SettingsForm Parent;
		private string Area;
		private string Course;

		public ClassSearchForm(SettingsForm parent, string course) {
			Parent = parent;
			Course = course.ToUpper();
			Area = Regex.Replace(course, @"\d+", "").ToUpper();

			InitializeComponent();

			CenterToScreen();
			
			// Get data
			string[] source = ClassUtilHandler.LoadData(Area);
			string[] classes = ClassUtilHandler.ParseClasses(Area, Course, source);
			DisplayClasses(classes);
		}

		private void DisplayClasses(string[] classes) {
			// Remove 'Loading classes...' item
			ClassBox.Items.RemoveAt(0);
			// Enable selection
			ClassBox.SelectionMode = SelectionMode.One;
			// Add classes
			foreach (string line in classes) {
				ClassBox.Items.Add(line);
			}
		}

		private void AddButton_Click(object sender, System.EventArgs e) {
			if (ClassBox.SelectedItems.Count == 1) {
				Parent.AddClass(Course + " - " + ClassBox.SelectedItem.ToString());
				Program.TrackedClasses.Add(Course + " - " + ClassBox.SelectedItem.ToString());
				Close();
			}
		}

		private void ClassBox_SelectedIndexChanged(object sender, System.EventArgs e) {
			// Enable button
			AddButton.Enabled = true;
		}
	}
}
