using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace LearningSystem.Models
{
    public class UniqueNameAttribute: ValidationAttribute
    {
        public string Msg { get; set; }

        ITIEntity context = new ITIEntity();

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            string name = value.ToString();

            Course courseReq = validationContext.ObjectInstance as Course;
            
            Course course = context.Courses.FirstOrDefault(c => c.Name == name);

            if (course == null || (course != null && course.Id == courseReq.Id))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Name is Exists");
        }

    }
}
