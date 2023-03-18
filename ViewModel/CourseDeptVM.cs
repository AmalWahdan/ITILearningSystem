using LearningSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningSystem.ViewModel
{
    [ModelMetadataType(typeof(CourseMetadata))]
    public partial class CourseDeptVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Degree { get; set; }
        public int minDegree { get; set; }
        [DisplayName("Dept Name")]
        public int Dept_Id { get; set; }
        public List<Department> Departments { get; set; }



    }
}
