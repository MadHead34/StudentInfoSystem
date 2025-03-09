public class SubjectDTO
{
    public int Id {get; set;}
    public String Name {get; set;}
    public Course Course {get; set;}
    public ICollection<Students> Students {get; set;} = new List<Students>();
}