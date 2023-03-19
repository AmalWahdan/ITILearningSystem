using LearningSystem.Models;

namespace LearningSystem.Repository
{
    public interface ICourseRepository
    {

        List<Course> GetAll();
        Course GetById(int id);
        Course GetByName(string name);
        void Insert(Course coure);
        void Update(Course coure);
        void Delete(int id);


    }
}
