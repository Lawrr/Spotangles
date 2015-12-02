using System;
using System.Windows.Forms;

namespace Spotangles {
    public partial class AlertForm : Form {

		public AlertForm(string[] availableClasses) {
			InitializeComponent();

			this.CenterToScreen();

			foreach (string availableClass in availableClasses) {
				this.ClassBox.Items.Add(availableClass);
			}
		}

		private void AlertForm_Load(object sender, EventArgs e) {
			this.Activate();
		}
	}
}
