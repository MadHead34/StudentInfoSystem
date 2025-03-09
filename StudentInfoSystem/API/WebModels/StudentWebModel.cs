public class StudentWebModel
{
     public int Id { get; set; }
        public string Name { get; set; } = string.Empty; 
        public string? CourseName { get; set; }
        public List<string> SubjectNames { get; set; }  
}