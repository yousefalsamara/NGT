using System.Collections.Generic;

namespace API.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public List<CourseTeacher> CourseTeacher { get; set; }
        public List<StudentCourseTeacher> StudentCourseTeacher { get; set; }
    }
}
