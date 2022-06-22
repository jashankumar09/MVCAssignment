using Microsoft.EntityFrameworkCore;
using SMSystem.Models;
namespace SMSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Enrollment>().HasOne(b => b.Course).WithMany(ba => ba.Enrollments).
                HasForeignKey(ci => ci.CourseId);
            modelbuilder.Entity<Enrollment>().HasOne(b => b.Student).WithMany(ba => ba.Enrollments).
                HasForeignKey(ci => ci.StudentId);
        }




        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }


    }
}
