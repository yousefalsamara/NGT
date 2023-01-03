using System.Collections.Generic;

namespace API.DTOs
{
    public class StudentCourseTeacherDto
    {
        public string StudentName { get; set; }
        public List<CourseDto>  Courses { get; set; }
        public List<TeacherDto> Teachers { get; set; }
    }
}
