using Microsoft.EntityFrameworkCore;

namespace DemoAPI_Rider.Models;


public class SchoolContext:DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public SchoolContext(DbContextOptions<SchoolContext> options):base(options){}
}