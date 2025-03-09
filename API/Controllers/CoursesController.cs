using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/courses")]
public class CoursesController : ControllerBase
{
    private readonly CourseService _courseService;

    public CoursesController(CourseService courseService)
    {
        _courseService = courseService;
    }

    // 🔹 Get all courses with WebModel conversion
    [HttpGet]
    public async Task<IActionResult> GetAllCourses()
    {
        var courses = await _courseService.GetAllCoursesAsync();

        var courseWebModels = courses.Select(c => new CourseWebModel
        {
            Id = c.Id,
            CourseName = c.CourseName,  
            Subjects = c.Subjects.Select(sub => sub.Name).ToList()
        }).ToList();

        return Ok(courseWebModels);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCourse(CourseWebModel courseWebModel)
    {
        // Convert WebModel -> ServiceModel
        var courseServiceModel = new CourseServiceModel
        {
            Id = courseWebModel.Id,
            CourseName = courseWebModel.CourseName,
            Subjects = courseWebModel.Subjects.Select(name => new SubjectServiceModel { Name = name }).ToList()
        };

        // Pass to service layer
        await _courseService.AddCourseAsync(courseServiceModel);

        return CreatedAtAction(nameof(GetAllCourses), new { id = courseWebModel.Id }, courseWebModel);
    }

  
    [HttpGet("count-no-subjects")]
    public async Task<ActionResult<int>> GetCoursesWithoutSubjectsCount()
    {   
        int count = await _courseService.GetCoursesWithoutSubjectsCountAsync();
        return Ok(count); 
    }

    // 🔹 Get courses without subjects with proper model conversion
    [HttpGet("no-subjects")]
    public async Task<ActionResult<List<CourseWebModel>>> GetCoursesWithoutSubjects()
    {   
        var courses = await _courseService.GetCoursesWithoutSubjectsAsync();

        var courseWebModels = courses.Select(c => new CourseWebModel
        {
            Id = c.Id,
            CourseName = c.CourseName,
            Subjects = new List<string>()
        }).ToList();

        return Ok(courseWebModels); 
    }
}

