public class Course 
{
    public int Id {get; set;}

    public String Name {get; set;}

    public String Description {get; set;}

    public ICollection<Students> Students { get; set; } = new List<Students>();
    public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}