using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Online_Learning_Platform.Models
{

    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
       
        public Course? Course { get; set; }
      
       
    }


}
