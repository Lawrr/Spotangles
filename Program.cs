using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spotangles {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		/// 

		public static List<string> trackedClasses = new List<string>();

		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
