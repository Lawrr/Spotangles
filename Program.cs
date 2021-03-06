﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Spotangles {
    static class Program {

        public static string ProgramName { get; private set; } = "Spotangles";
        public static string ProgramVersion { get; private set; } = "1.1.0";
		public static List<ClassDetails> TrackedClasses { get; private set; } = new List<ClassDetails>();
        public static MainForm MainForm { get; private set; }
        public static Tray Tray { get; private set; }

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

            MainForm = new MainForm();
            Tray = new Tray();

			Application.Run(MainForm);
		}

        private static void Application_ApplicationExit(object sender, EventArgs e) {
            // Make it so the icon doesnt stay when exiting the program
            Tray.TrayIcon.Visible = false;
        }
	}
}
