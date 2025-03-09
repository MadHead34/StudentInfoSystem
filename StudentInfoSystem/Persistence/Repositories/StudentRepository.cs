using Microsoft.EntityFrameworkCore;

public class StudentRepository
{
    private readonly StudentDbContext _context;

    public StudentRepository(StudentDbContext context)
    {
        _context = context;
    }

    public async Task<List<Students>> GetAllStudentsAsync()
    {
        return await _context.Students.Include(s => s.Course).ToListAsync();
    }

    public async Task<Students> GetStudentByIdAsync(int id)
    {
        return await _context.Students.Include(s => s.Course).FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task AddStudentAsync(Students student)
    {
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateStudentAsync(Students student)
    {
        _context.Students.Update(student);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteStudentAsync(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student != null)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<int> GetStudentCountWithoutCourseAsync()
    {
        return await _context.Students.CountAsync(s => s.CourseId == null);
    }

    public async Task<List<Students>> GetStudentsWithoutCourseAsync()
    {
        return await _context.Students
            .Where(s => s.CourseId == null)
            .Select(s => new Students
            {
                Id = s.Id,
                Name = s.Name
            }).ToListAsync();
    }
}