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

		private static string dataPattern = @"^<td.*?>\s*(\S+)\s*</td><td.*?>\s*(\S+?)\s*</td><td.*?>\s*(\S+?)\s*</td><td.*?>\s*(\S+)\s*</td><td.*?>\s*(\S+)\s*</td><td.*?>\s*(\d+)\s*/\s*(\d+).*";
		private static string timePattern = @".*?(\w+\s+\d+\-?(?:\d+)?).*";
		private static string commonPattern = @"^\w+\s+-\s+(.*?),\s+(.*?),\s+(.*?),.*";
		private static string coursePattern = @"^(\w+)\s+-\s+.*";

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
						   /* $1 = Activity
							* $2 = Section
							* $3 = Class Number
							* $4 = Type
							* $5 = Status
							* $6 = Current spots
							* $7 = Total spots
							*/
						classString = Regex.Replace(line, dataPattern, "$1, $2, $3, $5, $6/$7", RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);
					} else {
						string[] times = line.Split(';');
						string timeString = "";
						foreach (string time in times) {
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

		public static string GetUpdatedTime() {
			WebClient webClient = new WebClient();
			webClient.Proxy = null;
			string url = "https://my.unsw.edu.au/classutil/";

			string time = "";
			string[] lines = new string[0];
			try {
				Stream data = webClient.OpenRead(url);
				StreamReader read = new StreamReader(data);
				string content = read.ReadToEnd();
				lines = content.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
			} catch (WebException ex) {
				MessageBox.Show(ex.Message, null, MessageBoxButtons.OK);
			}
			string updatedLine = @"Data\s+is\s+correct\s+as\s+at\s+<b>(.*)</b></p>";
			if (lines.Length > 0) {
				foreach (string line in lines) {
					if (Regex.IsMatch(line, updatedLine, RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase)) {
						time = Regex.Replace(line, updatedLine, "$1", RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);
						break;
					}
				}
			}
			return time;
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

		public static string[] GetAvailableClasses(List<string> trackedClasses) {
			List<string> availableClasses = new List<string>();
			foreach (string trackedClass in trackedClasses) {
				string commonMatch = Regex.Replace(trackedClass, commonPattern, "$1 $2 $3", RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);
				string course = Regex.Replace(trackedClass, coursePattern, "$1", RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);
				string area = Regex.Replace(course, @"\d+", "").ToUpper();
				string[] source = LoadData(area);
				string[] classes = ParseClasses(area, course, source);
				string updatedClass = FindClass(commonMatch, classes);
				if (updatedClass != "") {
					// Search for number of spots
					string linePattern = @"(\S+?),\s+(\S+?),\s+(\S+?),\s+(\S+?),\s+(\d+)\s*/\s*(\d+).*";
				       /* $1 = Activity
						* $2 = Section
						* $3 = Class Number
						* $4 = Status
						* $5 = Current spots
						* $6 = Total spots
						*/
					string spots = Regex.Replace(updatedClass, linePattern, "$5 $6", RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);
					int currentSpots = 0;
					int totalSpots = 0;
					if (Int32.TryParse(spots.Split(' ')[0], out currentSpots) && Int32.TryParse(spots.Split(' ')[1], out totalSpots)) {
						if (currentSpots < totalSpots) {
							availableClasses.Add(updatedClass);
						}
					}
				}
			}

			return availableClasses.ToArray();
		}

		public static string FindClass(string commonMatch, string[] classes) {
			// Common match: LEC 1UGA 1234
			//         Activity Section ClassNumber
			string classString = "";

			foreach (string currClass in classes) {
				   /* $1 = Activity
					* $2 = Section
					* $3 = Class Number
					* $4 = Status
					* $5 = Current spots
					* $6 = Total spots
					*/
				string linePattern = @"(\S+?),\s+(\S+?),\s+(\S+?),\s+(\S+?),\s+(\d+)\s*/\s*(\d+).*";
				string currentCommonMatch = Regex.Replace(currClass, linePattern, "$1 $2 $3", RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);
				if (commonMatch.Equals(currentCommonMatch)) {
					classString = currClass;
					break;
				}
			}

			return classString;
		}
	}
}
