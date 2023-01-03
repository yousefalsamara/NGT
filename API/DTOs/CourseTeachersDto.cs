using System.Collections.Generic;

namespace API.DTOs
{
    public class CourseTeachersDto
    {
        public string CourseName { get; set; }
        public List<TeacherDto> Teachers { get; set; }
    }
}
