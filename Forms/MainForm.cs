using System;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace Spotangles {
    public partial class MainForm : Form {

		private NotifyIcon trayIcon;
		private ContextMenu trayMenu;
		private int numChecked = 0;
		private System.Timers.Timer timer;
		private AlertForm alertForm = null;
		private string updatedTime = "";

		public MainForm() {
			InitializeComponent();

			this.CenterToScreen();

			trayMenu = new ContextMenu();
			trayMenu.MenuItems.Add("Exit", OnExit);

			trayIcon = new NotifyIcon();
			trayIcon.Text = "Utilities";
            trayIcon.Icon = new Icon(Icon, 40, 40);

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
			if (alertForm == null) {
				this.Invoke(new Action(CheckClasses));
			}
		}

		private void CheckClasses() {
			string[] availableClasses = ClassUtilHandler.GetAvailableClasses(Program.trackedClasses);
			updatedTime = ClassUtilHandler.GetUpdatedTime();
			this.updatedTXT.Text = "Data is correct as at: " + updatedTime;
			numChecked++;
			this.statusTXT.Text = "Status: Started [Checked " + this.numChecked + " times]";
			if (availableClasses.Length > 0) {
				alertForm = new AlertForm(availableClasses);
				alertForm.ShowDialog();
				alertForm = null;
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
