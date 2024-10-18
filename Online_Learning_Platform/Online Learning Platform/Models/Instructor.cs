using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Learning_Platform.Models
{
    public class Instructor
    {
        [Key]
        public int InstructorId { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(20)]
        public string Name { get; set; }

        public string? Image { get; set; } 

        [ForeignKey("Track")]
        [Required]
        public int TrackId { get; set; }
        public Track? Tracks { get; set; }

        [ForeignKey("Course")]
        [Required]
        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
