public class CourseService
{
    private readonly CourseRepository _courseRepository;

    public CourseService(CourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<List<CourseServiceModel>> GetAllCoursesAsync()
    {
        var courses = await _courseRepository.GetAllCoursesAsync();

        return courses.Select(c => new CourseServiceModel
        {
            Id = c.Id,
            CourseName = c.Name,
            Subjects = c.Subjects.Select(s => new SubjectServiceModel
            {
                Id = s.Id,
                Name = s.Name
            }).ToList()
        }).ToList();
    }

    public async Task AddCourseAsync(CourseServiceModel courseServiceModel)
    {
        // 🔹 Convert from CourseServiceModel to Course entity
        var courseEntity = new Course
        {
            Id = courseServiceModel.Id,
            Name = courseServiceModel.CourseName,
            Subjects = courseServiceModel.Subjects.Select(s => new Subject
            {
                Id = s.Id,
                Name = s.Name
            }).ToList()
        };


        await _courseRepository.AddCourseAsync(courseEntity);
    }

    public async Task<int> GetCoursesWithoutSubjectsCountAsync()
    {
        return await _courseRepository.GetCoursesWithoutSubjectsCountAsync();
    }

    public async Task<List<CourseServiceModel>> GetCoursesWithoutSubjectsAsync()
    {
        var courses = await _courseRepository.GetCoursesWithoutSubjectsAsync();

        return courses.Select(c => new CourseServiceModel
        {
            Id = c.Id,
            CourseName = c.Name,
            Subjects = new List<SubjectServiceModel>() 
        }).ToList();
    }
}