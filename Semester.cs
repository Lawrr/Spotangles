namespace Spotangles {
    public enum Semester {
        One,
        Two,
        Summer
    }

    public static class SemesterExtensions {
        
        public static string ToShortString(this Semester semester) {
            return semester.GetId();
        }

        public static string GetId(this Semester semester) {
            string id = "";
            switch (semester) {
                case Semester.One:
                    id = "S1";
                    break;

                case Semester.Two:
                    id = "S2";
                    break;

                case Semester.Summer:
                    id = "X1";
                    break;

                default:
                    id = "S1";
                    break;
            }
            return id;
        }

        public static Semester Parse(string semesterString) {
            Semester semester;
            switch (semesterString.ToLower()) {
                case "semester 1":
                    semester = Semester.One;
                    break;

                case "semester 2":
                    semester = Semester.Two;
                    break;

                case "summer":
                    semester = Semester.Summer;
                    break;

                default:
                    semester = Semester.One;
                    break;

            }
            return semester;
        }

    }
}
