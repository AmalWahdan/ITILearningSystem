using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningSystem.Models
{
    
    public partial class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Degree { get; set; }
        public int minDegree { get; set; }

        [DisplayName("Dept Name")]

        [ForeignKey("Department")]
        public int Dept_Id { get; set; }

        public virtual Department? Department { get; set; }


    }
}
