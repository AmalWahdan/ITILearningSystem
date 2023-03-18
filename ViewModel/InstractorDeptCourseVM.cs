using LearningSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningSystem.ViewModel
{
    public class InstractorDeptCourseVM
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }    
        public int Dept_Id { get; set; }
        public int Crs_Id { get; set; }
        public List< Department> Departments { get; set; }
        public List<Course >Courses { get; set; }
    }
}
