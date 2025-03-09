public class CourseServiceModel
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int StudentCount { get; set; }
        public List<SubjectServiceModel> Subjects { get; set; }
    }