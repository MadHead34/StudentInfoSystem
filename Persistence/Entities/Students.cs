public class Students
{
    public int Id {get; set;}
    public String Name {get; set;}  = string.Empty;
    public int? CourseId {get; set;}
    public Course? Course {get; set;}

    public ICollection<Subject> Subjects {get; set;} = new List<Subject>();

}