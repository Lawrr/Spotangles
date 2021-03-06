﻿using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Spotangles {
	public partial class ClassSearchForm : Form {

        public SettingsForm SettingsFormParent { get; private set; }
		public string Area { get; private set; }
		public string Course { get; private set; }

		public ClassSearchForm(SettingsForm settingsFormParent, string course, Semester semester) {
            SettingsFormParent = settingsFormParent;
			Course = course.ToUpper();
			Area = Regex.Replace(course, @"\d+", "").ToUpper();

			InitializeComponent();

			CenterToScreen();
			
			// Get data
			string[] source = ClassUtilHandler.LoadData(Area, semester);
			List<ClassDetails> classes = ClassUtilHandler.ParseClasses(Area, Course, semester, source);
			DisplayClasses(classes);
		}

		private void DisplayClasses(List<ClassDetails> classes) {
			// Remove 'Loading classes...' item
			ClassBox.Items.RemoveAt(0);

			// Enable selection
			ClassBox.SelectionMode = SelectionMode.One;

            // Add classes
			foreach (ClassDetails c in classes) {
				ClassBox.Items.Add(c);
			}
		}

		private void AddButton_Click(object sender, System.EventArgs e) {
			if (ClassBox.SelectedItems.Count == 1) {
                ClassDetails selectedClass = (ClassDetails)ClassBox.SelectedItem;
                SettingsFormParent.AddClass(selectedClass);
				Program.TrackedClasses.Add(selectedClass);
				Close();
			}
		}

		private void ClassBox_SelectedIndexChanged(object sender, System.EventArgs e) {
			// Enable button
			AddButton.Enabled = true;
		}
	}
}
