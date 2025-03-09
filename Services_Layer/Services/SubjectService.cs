using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class SubjectService
{
    private readonly SubjectRepository _subjectRepository;

    public SubjectService(SubjectRepository subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }

    public async Task<List<SubjectServiceModel>> GetAllSubjectsAsync()
    {
        var subjects = await _subjectRepository.GetAllSubjectsAsync();

        return subjects.Select(s => new SubjectServiceModel
        {
            Name = s.Name,
            Students = s.Students.Select(student => new StudentServiceModel
            {
                Id = student.Id,
                Name = student.Name
            }).ToList() 
        }).ToList();
    }

    public async Task AddSubjectAsync(SubjectServiceModel subjectServiceModel)
    {
        // 🔹 Convert from CourseServiceModel to Course entity
        var courseEntity = new Subject
        {
            Id = subjectServiceModel.Id,
            Name = subjectServiceModel.Name,
        };


        await _subjectRepository.AddSubjectAsync(courseEntity);
    }

    public async Task<List<Subject>> GetSubjectsWithStudents()
    {
        return await _subjectRepository.GetSubjectsWithStudentsAsync(); 
    }
}