using Microsoft.EntityFrameworkCore;

namespace LearningSystem.Models
{
    public class ITIEntity : DbContext
    {



        public ITIEntity(DbContextOptions options) : base(options)
        {

        }

      

        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<crsResult> crsResults { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Trainee> Trainees { get; set; }

    }
}
