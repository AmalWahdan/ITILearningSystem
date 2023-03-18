using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LearningSystem.Models
{

    [ModelMetadataType(typeof(CourseMetadata))]
    public partial class Course
    {
    }

    public class CourseMetadata
    {

        public int Id { get; set; }
        [MinLength(2, ErrorMessage = "Name must be more than 1 Char")]
        [MaxLength(20, ErrorMessage = "Name must be less than 21 letter")]
        [UniqueName(Msg = "Name  must be unique")]
        public string Name { get; set; }

        [Range(minimum: 50, maximum: 100)]
        public int Degree { get; set; }

        [Remote("CheckminDegree", "Course", AdditionalFields = "Degree", ErrorMessage = "MinDegree must be less than Degree")]
        public int minDegree { get; set; }

        [DisplayName("Dept Name")]
        public int Dept_Id { get; set; }


    }
}
