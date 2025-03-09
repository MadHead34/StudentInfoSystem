using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/students")]
public class StudentsController : ControllerBase
{
    private readonly StudentService _studentService;

    public StudentsController(StudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStudents()
    {
        var students = await _studentService.GetAllStudentsAsync();

        var studentWebModels = students.Select(s => new StudentWebModel
        {
            Id = s.Id,
            Name = s.Name,
            CourseName = s.CourseName,  
            SubjectNames = s.SubjectNames
        }).ToList();

        return Ok(studentWebModels);
    }

    [HttpPost]
    public async Task<IActionResult> CreateStudent(StudentWebModel studentWebModel)
    {
        // Convert WebModel -> ServiceModel
        var courseServiceModel = new StudentServiceModel
        {
            Id = studentWebModel.Id,
            Name = studentWebModel.Name,
        };

        await _studentService.AddStudentAsync(courseServiceModel);

        return CreatedAtAction(nameof(GetAllStudents), new { id = studentWebModel.Id }, studentWebModel);
    }

    [HttpGet("count-no-course")]
    public async Task<IActionResult> GetStudentCountWithoutCourse()
    {
        var count = await _studentService.GetStudentCountWithoutCourse();
        return Ok(count);
    }

    [HttpGet("no-course")]
    public async Task<IActionResult> GetStudentWithoutCourse()
    {
        var students = await _studentService.GetStudentsWithoutCourseAsync();

        var studentWebModels = students.Select(c => new StudentWebModel
        {
            Id = c.Id,
            Name = c.Name,
            CourseName = c.CourseName,
        }).ToList();

        return Ok(studentWebModels);

    }
}