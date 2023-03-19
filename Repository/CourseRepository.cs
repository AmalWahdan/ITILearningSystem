using LearningSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningSystem.Repository
{
    public class CourseRepository : ICourseRepository
    {
        ITIEntity context;
        public CourseRepository(ITIEntity context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            Course course =GetById(id);

            if (course != null)
            {
                context.Courses.Remove(course);
                context.SaveChanges();
            }
        }

        public List<Course> GetAll()
        {
            return context.Courses.Include(s => s.Department).ToList();
        }

        public Course GetById(int id)
        {
            return context.Courses.FirstOrDefault(s => s.Id == id);
        }

        public Course GetByName(string name)
        {
            return context.Courses.FirstOrDefault(c => c.Name == name);
        }

        public void Insert(Course coure)
        {
            context.Courses.Add(coure);
            context.SaveChanges();
        }

        public void Update( Course coure)
        {
            context.Update(coure);
            context.SaveChanges();
        }
    }
}
