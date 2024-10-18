using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Learning_Platform.Models
{
    public class Course
    {
       
        [Key]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, ErrorMessage = "Title cannot be longer than 200 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [DataType(DataType.Upload)]
        public string ? ImageUrl { get; set; } 

        // Foreign Key to Track
        public int TrackId { get; set; }
        [ForeignKey("TrackId")]
        public Track ?Track { get; set; }  
        public List<Enrollment>? Enrollments { get; set; }
    }


}
