using System.Collections.Generic;

namespace API.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public List<CourseTeacher> CourseTeacher { get; set; }
        public List<StudentCourseTeacher> StudentCourseTeacher { get; set; }
    }
}
