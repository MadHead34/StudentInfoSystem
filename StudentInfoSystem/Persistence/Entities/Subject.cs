public class Subject
{
    public int Id {get; set;}
    public String Name {get; set;}
    public int CourseId {get; set;}
    public Course Course {get; set;}
    public ICollection<Students> Students {get; set;} = new List<Students>();


}