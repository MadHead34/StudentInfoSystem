using Microsoft.EntityFrameworkCore;

public class StudentDbContext : DbContext
{
    public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }

    public DbSet<Students> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Subject> Subjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Students>()
            .HasOne(s => s.Course)
            .WithMany(s => s.Students)
            .HasForeignKey(ss => ss.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Subject>()
            .HasOne(ss => ss.Course)
            .WithMany(s => s.Subjects)
            .HasForeignKey(ss => ss.CourseId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}