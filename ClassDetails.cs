using System.Collections.Generic;

namespace Spotangles {
    public class ClassDetails {

        public string CourseCode { get; private set; }
        public Semester Semester { get; private set; }

        public string Activity { get; private set; }
        public string Section { get; private set; }
        public int ClassNumber { get; private set; }
        public string Type { get; private set; }
        public string Status { get; private set; }
        public int CurrentSpots { get; private set; }
        public int TotalSpots { get; private set; }

        public List<string> Times { get; private set; } = new List<string>();

        public ClassDetails(string courseCode, string activity, string section, int classNumber,
                     string type, string status, int currentSpots, int totalSpots) {
            CourseCode = courseCode;
            Activity = activity;
            Section = section;
            ClassNumber = classNumber;
            Type = type;
            Status = status;
            CurrentSpots = currentSpots;
            TotalSpots = totalSpots;
        }

        public void AddTime(string time) {
            Times.Add(time);
        }

        public override string ToString() {
            return string.Format("{0} - {1}, {2}, {3}, {4}, {5}, {6}/{7} [{8}]",
                                 CourseCode, Activity, Section, ClassNumber, Type, Status, CurrentSpots, TotalSpots,
                                 string.Join(", ", Times));
        }
    }
}
