public class StudentServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? CourseId { get; set; }  
        public String? CourseName { get; set; }  
        public List<string> SubjectNames { get; set; }    
}