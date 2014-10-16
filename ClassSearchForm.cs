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
			this.classBox.Items.RemoveAt(0);
			// Enable selection
			this.classBox.SelectionMode = SelectionMode.One;
			// Add classes
			foreach (string line in classes) {
				this.classBox.Items.Add(line);
			}
		}

		private void addBTN_Click(object sender, System.EventArgs e) {
			if (this.classBox.SelectedItems.Count == 1) {
				Parent.AddClass(this.Course + " - " + this.classBox.SelectedItem.ToString());
				Program.trackedClasses.Add(this.Course + " - " + this.classBox.SelectedItem.ToString());
				this.Close();
			}
		}

		private void classBox_SelectedIndexChanged(object sender, System.EventArgs e) {
			// Enable button
			this.addBTN.Enabled = true;
		}
	}
}
