namespace Spotangles {
    public class Class {

        public string CourseCode { get; private set; }
        public Semester Semester { get; private set; }

        public string Activity { get; private set; }
        public string Section { get; private set; }
        public int ClassNumber { get; private set; }
        public string Status { get; private set; }
        public int CurrentSpots { get; private set; }
        public int TotalSpots { get; private set; }

        public Class() {
        }
    }
}
