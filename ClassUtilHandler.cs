using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Spotangles {
    static class ClassUtilHandler {

        /* $1 = Activity
         * $2 = Section
         * $3 = Class Number
         * $4 = Type
         * $5 = Status
         * $6 = Current spots
         * $7 = Total spots
         */
        private static string DataPattern = @"^<td.*?>\s*(\S+)\s*</td><td.*?>\s*(\S+?)\s*</td><td.*?>\s*(\S+?)\s*</td><td.*?>\s*(\S+)\s*</td><td.*?>\s*(\S+)\s*</td><td.*?>\s*(\d+)\s*/\s*(\d+).*";
		private static string TimePattern = @".*?(\w+\s+\d+\-?(?:\d+)?).*";

		public static List<Class> ParseClasses(string area, string course, string[] source) {
			List<Class> classes = new List<Class>();

			bool foundCourse = false;
			Class currClass = null;
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
                        Regex lineRegex = new Regex(DataPattern, RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);
                        Match lineMatch = lineRegex.Match(line);
                        if (lineMatch.Success) {
                            try {
                                currClass = new Class(course,
                                                      lineMatch.Groups[1].Value,
                                                      lineMatch.Groups[2].Value,
                                                      int.Parse(lineMatch.Groups[3].Value),
                                                      lineMatch.Groups[4].Value,
                                                      lineMatch.Groups[5].Value,
                                                      int.Parse(lineMatch.Groups[6].Value),
                                                      int.Parse(lineMatch.Groups[7].Value));
                            } catch (FormatException e) {
                                continue;
                            }
                        }
					} else {
						string[] times = line.Split(';');
						foreach (string time in times) {
                            Regex timeRegex = new Regex(TimePattern, RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);
                            Match timeMatch = timeRegex.Match(time);
                            if (timeMatch.Success && currClass != null) {
                                currClass.AddTime(timeMatch.Groups[1].Value);
                            }
						}
						if (Regex.IsMatch(line, TimePattern, RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase)) {
							classes.Add(currClass);
						}
					}
				}
			}

			return classes;
		}

		public static string GetUpdatedTime() {
			WebClient webClient = new WebClient();
			webClient.Proxy = null;
            string url = "http://classutil.unsw.edu.au/";

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
            string url = String.Format("http://classutil.unsw.edu.au/{0}_S1.html", area);

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

		public static List<Class> GetAvailableClasses(List<Class> trackedClasses) {
			List<Class> availableClasses = new List<Class>();
			foreach (Class trackedClass in trackedClasses) {
				string area = Regex.Replace(trackedClass.CourseCode, @"\d+", "").ToUpper();
				string[] source = LoadData(area);
				List<Class> updatedClasses = ParseClasses(area, trackedClass.CourseCode, source);
                // Find trackedClass from updatedClasses
                Class updatedClass = null;
                foreach (Class c in updatedClasses) {
                    if (c.ClassNumber == trackedClass.ClassNumber) {
                        updatedClass = c;
                        break;
                    }
                }
				if (updatedClass != null) {
                    if (trackedClass.CurrentSpots < trackedClass.TotalSpots) {
                        availableClasses.Add(updatedClass);
                    }
				}
			}

			return availableClasses;
		}

	}
}
