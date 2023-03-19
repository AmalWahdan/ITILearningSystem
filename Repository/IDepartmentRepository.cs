using LearningSystem.Models;

namespace LearningSystem.Repository
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();
    }
}
