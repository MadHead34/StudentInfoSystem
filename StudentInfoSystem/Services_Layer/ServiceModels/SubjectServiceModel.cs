public class SubjectServiceModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<StudentServiceModel> Students { get; set; }
}