using Moq;
using Xunit;

public class SubjectServiceTests
{
    private readonly SubjectService _subjectService;
    private readonly Mock<SubjectRepository> _mockRepo;
    private readonly Mock<StudentDbContext> _mockDbContext;

    public SubjectServiceTests()
    {
        _mockRepo = new Mock<SubjectRepository>();
        _mockDbContext = new Mock<StudentDbContext>();
        _subjectService = new SubjectService(_mockRepo.Object);
    }

    [Fact]
    public async Task GetAllSubjectsAsync_ReturnsSubjects()
    {
        // Arrange
        var subjects = new List<Subject>
        {
            new Subject { Id = 1, Name = "Algorithms" },
            new Subject { Id = 2, Name = "Data Structure" }
        };

        _mockRepo.Setup(repo => repo.GetAllSubjectsAsync()).ReturnsAsync(subjects); // Ensure method matches repo

        // Act
        var result = await _subjectService.GetAllSubjectsAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
    }
}