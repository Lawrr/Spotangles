using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spotangles {
	static class ClassUtilHandler {
		public static string[] ParseClasses(string area, string course, string[] source) {
			List<string> classes = new List<string>();

			bool foundCourse = false;
			string classString = "";
			foreach (string line in source) {
				int courseIndex = line.IndexOf(@"<a name=""" + course, StringComparison.OrdinalIgnoreCase);
				int anyCourseIndex = line.IndexOf(@"<a name=""" + area, StringComparison.OrdinalIgnoreCase);
				if (courseIndex >= 0) {
					foundCourse = true;
				} else if (foundCourse && anyCourseIndex >= 0) {
					// Next course has started
					break;
				} else if (foundCourse) {
					if (line.IndexOf("</td> </tr>", StringComparison.OrdinalIgnoreCase) < 0) {
						Console.WriteLine("No: " + line);
						string linePattern = @"^<td.*?>\s*(\S+)\s*</td><td.*?>\s*(\S+?)\s*</td><td.*?>\s*(\S+?)\s*</td><td.*?>\s*(\S+)\s*</td><td.*?>\s*(\S+)\s*</td><td.*?>\s*(\d+)\s*/\s*(\d+).*";
						/* $1 = Activity
							* $2 = Section
							* $3 = Class Number
							* $4 = Type
							* $5 = Status
							* $6 = Current spots
							* $7 = Total spots
							*/
						classString = Regex.Replace(line, linePattern, "$1, $2, $5, $6/$7", RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);
					} else {
						Console.WriteLine("On: " + line);
						string[] times = line.Split(';');
						string timeString = "";
						string timePattern = @".*?(\w+\s+\d+\-?(?:\d+)?).*";
						foreach (string time in times) {
							Console.WriteLine("Time: " + time);
							if (timeString.Length > 0) {
								timeString += ", ";
							}
							timeString += Regex.Replace(line, timePattern, "$1", RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);
						}
						if (Regex.IsMatch(line, timePattern, RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase)) {
							classes.Add(classString + ", [" + timeString + "]");
						}
					}
				}
			}

			return classes.ToArray();
		}

		public static string[] LoadData(string area) {
			WebClient webClient = new WebClient();
			webClient.Proxy = null;
			string url = String.Format("https://my.unsw.edu.au/classutil/{0}_S1.html", area);

			try {
				Stream data = webClient.OpenRead(url);
				StreamReader read = new StreamReader(data);
				string content = read.ReadToEnd();
				string[] lines = content.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
				return lines;
			} catch (WebException ex) {
				MessageBox.Show(ex.Message, null, MessageBoxButtons.OK);
			}
			return new string[0];
		}
	}
}
