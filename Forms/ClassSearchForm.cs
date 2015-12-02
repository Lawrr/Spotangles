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

			this.CenterToScreen();
			
			// Get data
			string[] source = ClassUtilHandler.LoadData(Area);
			string[] classes = ClassUtilHandler.ParseClasses(Area, Course, source);
			DisplayClasses(classes);
		}

		private void DisplayClasses(string[] classes) {
			// Remove 'Loading classes...' item
			this.ClassBox.Items.RemoveAt(0);
			// Enable selection
			this.ClassBox.SelectionMode = SelectionMode.One;
			// Add classes
			foreach (string line in classes) {
				this.ClassBox.Items.Add(line);
			}
		}

		private void AddButton_Click(object sender, System.EventArgs e) {
			if (this.ClassBox.SelectedItems.Count == 1) {
				Parent.AddClass(this.Course + " - " + this.ClassBox.SelectedItem.ToString());
				Program.TrackedClasses.Add(this.Course + " - " + this.ClassBox.SelectedItem.ToString());
				this.Close();
			}
		}

		private void ClassBox_SelectedIndexChanged(object sender, System.EventArgs e) {
			// Enable button
			this.AddButton.Enabled = true;
		}
	}
}
