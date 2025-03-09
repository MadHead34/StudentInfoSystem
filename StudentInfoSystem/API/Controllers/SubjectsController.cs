using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
    [Route("api/subjects")]
    public class SubjectsController : ControllerBase
    {
        private readonly SubjectService _subjectService;

        public SubjectsController(SubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubjects()
        {
            var subjects = await _subjectService.GetAllSubjectsAsync();

            var subjectWebModels = subjects.Select(s => new SubjectWebModel
            {
                Name = s.Name,
                Students = s.Students.Select(stu => stu.Name).ToList()
            }).ToList();

            return Ok(subjectWebModels);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubject(SubjectWebModel subjectWebModel)
        {
             var subjectServiceModel = new SubjectServiceModel
        {
            Name = subjectWebModel.Name
        };

        // Pass to service layer
        await _subjectService.AddSubjectAsync(subjectServiceModel);

        return CreatedAtAction(nameof(GetAllSubjects), new { id = subjectWebModel.Id }, subjectWebModel);
        }

        [HttpGet("students")]
        public async Task<IActionResult> GetSubjectsWithStudents()
        {
            var subjects = await _subjectService.GetSubjectsWithStudents();

            var subjectWebModels = subjects.Select(s => new SubjectWebModel
            {
                Id = s.Id,
                Name = s.Name,
                Students = s.Students.Select(stu => stu.Name).ToList()
            }).ToList();

            return Ok(subjectWebModels);
        }
}