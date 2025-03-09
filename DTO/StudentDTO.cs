public class StudentDTO
{
    public int Id {get; set;}
    public String Name {get; set;}
    public Course Course {get; set;}
    public ICollection<Subject> Subjects {get; set;} = new List<Subject>();
}