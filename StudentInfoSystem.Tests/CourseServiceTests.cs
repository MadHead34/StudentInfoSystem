using Moq;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class CourseServiceTests
{
    private readonly CourseService _courseService;
    private readonly Mock<CourseRepository> _mockRepo;
    private readonly Mock<StudentDbContext> _mockDbContext;

    public CourseServiceTests()
    {
        _mockRepo = new Mock<CourseRepository>();
        _courseService = new CourseService(_mockRepo.Object);
    }

    [Fact]
    public async Task GetAllCoursesAsync_ReturnsCourses()
    {
        // Arrange
        var course = new List<Course>
        {
            new Course { Id = 1, Name = "Computer Science" },
            new Course { Id = 2, Name = "Data Analysis" }
        };

        _mockRepo.Setup(repo => repo.GetAllCoursesAsync()).ReturnsAsync(course); // Ensure method matches repo

        // Act
        var result = await _courseService.GetAllCoursesAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
    }
}