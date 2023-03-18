using System.ComponentModel.DataAnnotations.Schema;

namespace LearningSystem.Models
{
    public class crsResult
    {
        public int Id { get; set; }
        public int  Degree { get; set; }
    

        [ForeignKey("Trainee")]
        public int Trainee_Id { get; set; }

        [ForeignKey("Course")]
        public int Crs_Id { get; set; }

        public virtual Trainee Trainee  { get; set; }
        public virtual Course Course { get; set; }



    }
}
