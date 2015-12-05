using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Spotangles {
    public partial class AlertForm : Form {

		public AlertForm(List<ClassDetails> availableClasses) {
			InitializeComponent();

			CenterToScreen();

			foreach (ClassDetails availableClass in availableClasses) {
				ClassBox.Items.Add(availableClass);
			}
		}

		private void AlertForm_Load(object sender, EventArgs e) {
			Activate();
		}
	}
}
