namespace API.Models
{
    public class CourseTeacher
    {
        public Course Course { get; set; }
        public int CourseId { get; set; }
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
    }
}
