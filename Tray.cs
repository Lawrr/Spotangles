﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Spotangles {
    public class Tray {

        public NotifyIcon TrayIcon { get; private set; }
        private ContextMenu ContextMenu;

        public Tray() {
            // Context menu
            ContextMenu = new ContextMenu();
            ContextMenu.MenuItems.Add("Open " + Program.ProgramName, TrayIcon_OpenClick);
            ContextMenu.MenuItems.Add("-");
            ContextMenu.MenuItems.Add("Exit", TrayIcon_ExitClick);

            // Tray icon
            TrayIcon = new NotifyIcon();
            TrayIcon.Text = Program.ProgramName;
            TrayIcon.Icon = new Icon(Program.MainForm.Icon, 40, 40);
            TrayIcon.ContextMenu = ContextMenu;
            TrayIcon.Visible = true;

            // Event handlers
            TrayIcon.DoubleClick += new EventHandler(TrayIcon_DoubleClick);
        }

		private void TrayIcon_DoubleClick(object sender, EventArgs e) {
            Program.MainForm.Open();
		}

        private void TrayIcon_OpenClick(object sender, EventArgs e) {
            Program.MainForm.Open();
        }

		private void TrayIcon_ExitClick(object sender, EventArgs e) {
			Application.ExitThread();
		}

    }
}
