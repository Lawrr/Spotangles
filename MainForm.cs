using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Spotangles {
	public partial class MainForm : Form {

		private NotifyIcon trayIcon;
		private ContextMenu trayMenu;
		private int numChecked = 0;
		private System.Timers.Timer timer;

		public MainForm() {
			InitializeComponent();

			trayMenu = new ContextMenu();
			trayMenu.MenuItems.Add("Exit", OnExit);

			trayIcon = new NotifyIcon();
			trayIcon.Text = "Utilities";
			trayIcon.Icon = new Icon(".../.../Resources/Icon.ico");

			trayIcon.ContextMenu = trayMenu;
			trayIcon.Visible = true;

			trayIcon.DoubleClick += new EventHandler(trayIcon_DoubleClick);

			timer = new System.Timers.Timer(1000 * 60 * 5);
			timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);

			this.statusTXT.Text = "Status: Idle";
			this.stopBTN.Enabled = false;
		}

		private void trayIcon_DoubleClick(object sender, EventArgs e) {
			Visible = !Visible;
		}

		private void OnExit(object sender, EventArgs e) {
			Application.Exit();
		}

		private void timer_Elapsed(object sender, EventArgs e) {
			CheckClasses();
		}

		private void CheckClasses() {
			string[] availableClasses = ClassUtilHandler.GetAvailableClasses(Program.trackedClasses);
			numChecked++;
			this.statusTXT.Text = "Status: Started [Checked " + this.numChecked + " times]";
			if (availableClasses.Length > 0) {
				AlertForm alertForm = new AlertForm(availableClasses);
				alertForm.ShowDialog();
			}
		}

		private void settingsBTN_Click(object sender, EventArgs e) {
			SettingsForm settingsForm = new SettingsForm();
			settingsForm.ShowDialog();
		}

		private void startBTN_Click(object sender, EventArgs e) {
			this.statusTXT.Text = "Status: Started [Checked " + this.numChecked + " times]";
			this.settingsBTN.Enabled = false;
			this.stopBTN.Enabled = true;
			this.startBTN.Enabled = false;
			CheckClasses();
			timer.Start();
		}

		private void stopBTN_Click(object sender, EventArgs e) {
			this.statusTXT.Text = "Status: Idle";
			this.numChecked = 0;
			this.settingsBTN.Enabled = true;
			this.startBTN.Enabled = true;
			this.stopBTN.Enabled = false;
			timer.Stop();
		}
	}
}
