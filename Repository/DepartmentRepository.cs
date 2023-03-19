using LearningSystem.Models;

namespace LearningSystem.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        ITIEntity context;
        public DepartmentRepository(ITIEntity context)
        {
            this.context = context;
        }

        public List<Department> GetAll()
        {
          return  context.Departments.ToList();
        }
    }
}
