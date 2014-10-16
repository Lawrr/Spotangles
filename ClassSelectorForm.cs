using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Spotangles {
	public partial class ClassSelectorForm : Form {

		private string Area;
		private string Course;

		public ClassSelectorForm(string course) {
			Course = course;
			Area = Regex.Replace(course, @"\d+", "").ToUpper();

			InitializeComponent();
			
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
			// Enable button
			this.addBTN.Enabled = true;
			// Add classes
			foreach (string line in classes) {
				this.classBox.Items.Add(line);
			}
		}
	}
}
