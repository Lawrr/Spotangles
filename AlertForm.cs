using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spotangles {
	public partial class AlertForm : Form {
		public AlertForm(string[] availableClasses) {
			InitializeComponent();

			foreach (string availableClass in availableClasses) {
				this.classBox.Items.Add(availableClass);
			}
		}

		private void AlertForm_Load(object sender, EventArgs e) {
			this.Activate();
		}
	}
}
