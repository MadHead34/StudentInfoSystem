using Microsoft.EntityFrameworkCore;

public class CourseRepository
{
    private readonly StudentDbContext _context;

    public CourseRepository(StudentDbContext context)
    {
        _context = context;
    }

    public async Task<List<Course>> GetAllCoursesAsync()
    {
        return await _context.Courses.ToListAsync();
    }

    public async Task<Course> GetCourseByIdAsync(int id)
    {
        return await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddCourseAsync(Course course)
    {
        await _context.Courses.AddAsync(course);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCourseAsync(Course course)
    {
        _context.Courses.Update(course);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCourseAsync(int id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course != null)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<int> GetCoursesWithoutSubjectsCountAsync()
    {
        return await _context.Courses.CountAsync(c => !c.Subjects.Any()); 
    }

     public async Task<List<Course>> GetCoursesWithoutSubjectsAsync()
    {
        return await _context.Courses
            .Where(c => !c.Subjects.Any())
            .Select(c => new Course
            {
                Id = c.Id,
                Name = c.Name
            }).ToListAsync();
    }
 
}