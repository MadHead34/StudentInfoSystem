using Moq;
using Xunit;


public class StudentServiceTests
{
    private readonly StudentService _studentService;
    private readonly Mock<StudentRepository> _mockRepo;

    public StudentServiceTests()
    {
        _mockRepo = new Mock<StudentRepository>();
        _studentService = new StudentService(_mockRepo.Object);
    }

    [Fact]
    public async Task GetAllStudentsAsync_ReturnsStudents()
    {
        var students = new List<Students>
        {
            new Students { Id = 1, Name = "John Doe" },
            new Students { Id = 2, Name = "Jane Doe" }
        };

        _mockRepo.Setup(repo => repo.GetAllStudentsAsync()).ReturnsAsync(students); // Ensure method matches repo

        var result = await _studentService.GetAllStudentsAsync();

        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
    }
}
