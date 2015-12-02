using System;
using System.Windows.Forms;

namespace Spotangles {
    public partial class AlertForm : Form {

		public AlertForm(string[] availableClasses) {
			InitializeComponent();

			CenterToScreen();

			foreach (string availableClass in availableClasses) {
				ClassBox.Items.Add(availableClass);
			}
		}

		private void AlertForm_Load(object sender, EventArgs e) {
			Activate();
		}
	}
}
