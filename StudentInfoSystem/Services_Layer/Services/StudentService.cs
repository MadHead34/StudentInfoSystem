using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class StudentService
{
    private readonly StudentRepository _studentRepository;
    public StudentService(StudentDbContext context, StudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<List<StudentServiceModel>> GetAllStudentsAsync()
    {
        var students = await _studentRepository.GetAllStudentsAsync();

        return students.Select(s => new StudentServiceModel
        {
            Id = s.Id,
            Name = s.Name,
            CourseId = s.CourseId,
            CourseName = s.Course?.Name,
            SubjectNames = s.Subjects.Select(sub => sub.Name).ToList()
        }).ToList();
    }

    public async Task AddStudentAsync(StudentServiceModel studentServiceModel)
    {
        var courseEntity = new Students
        {
            Id = studentServiceModel.Id,
            Name = studentServiceModel.Name,
            CourseId = studentServiceModel.CourseId,
        };


        await _studentRepository.AddStudentAsync(courseEntity);
    }

    public async Task<int> GetStudentCountWithoutCourse()
    {
        return await _studentRepository.GetStudentCountWithoutCourseAsync();
    }

    public async Task<List<StudentServiceModel>> GetStudentsWithoutCourseAsync()
    {
        var students = await _studentRepository.GetStudentsWithoutCourseAsync();

        var studentServiceModels = students.Select(s => new StudentServiceModel
        {
            Id = s.Id,
            Name = s.Name,
            CourseId = s.CourseId,  
        }).ToList();

        return studentServiceModels;
    }
}