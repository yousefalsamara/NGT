namespace API.DTOs
{
    public class UpdateStudentDto
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
    }
}
