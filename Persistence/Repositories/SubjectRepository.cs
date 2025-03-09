using Microsoft.EntityFrameworkCore;

public class SubjectRepository
{
    private readonly StudentDbContext _context;

    public SubjectRepository(StudentDbContext context)
    {
        _context = context;
    }

    public async Task<List<Subject>> GetAllSubjectsAsync()
    {
        return await _context.Subjects.Include(s => s.Course).ToListAsync();
    }

    public async Task<Subject> GetSubjectByIdAsync(int id)
    {
        return await _context.Subjects.Include(s => s.Course).FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task AddSubjectAsync(Subject subject)
    {
        await _context.Subjects.AddAsync(subject);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateSubjectAsync(Subject subject)
    {
        _context.Subjects.Update(subject);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteSubjectAsync(int id)
    {
        var subject = await _context.Subjects.FindAsync(id);
        if (subject != null)
        {
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Subject>> GetSubjectsWithStudentsAsync()
    {
        return await _context.Subjects
            .Include(s => s.Course)
            .ThenInclude(s => s.Students) 
            .Select(s => new Subject
            {
                Id = s.Id,
                Name = s.Name,
                Students = s.Course.Students
               
            }).ToListAsync();
    }



}