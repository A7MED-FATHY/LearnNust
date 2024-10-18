using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Learning_Platform.Models
{
    public class Track
    {
        [Key]
        public int TrackId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public string? ImageUrl { get; set; } 
     
       
        public List< Instructor>? Instructor { get; set; } 
        public List<Course>? Courses { get; set; }
    }


}
