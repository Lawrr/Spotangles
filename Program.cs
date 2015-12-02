using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Spotangles {
    static class Program {

		public static List<string> trackedClasses = new List<string>();

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
