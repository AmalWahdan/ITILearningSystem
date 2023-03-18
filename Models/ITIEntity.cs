using Microsoft.EntityFrameworkCore;

namespace LearningSystem.Models
{
    public class ITIEntity : DbContext
    {

       public ITIEntity():base()
        {

        }
        protected override void  OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-FUG26SB;Database=ITISystem;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<crsResult> crsResults { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Trainee> Trainees { get; set; }

    }
}
