using Online_Learning_Platform.Models;

public class InstructorCreateViewModel
{
    public Instructor Instructor { get; set; }
    public int[] SelectedTrackIds { get; set; }
    public int[] SelectedCourseIds { get; set; }
    public IEnumerable<Track> Tracks { get; set; }
    public IEnumerable<Course> Courses { get; set; }
}
