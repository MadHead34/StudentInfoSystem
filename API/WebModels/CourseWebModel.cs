public class CourseWebModel
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int StudentCount { get; set; }
        public List<string> Subjects { get; set; }
    }