﻿using System.Collections.Generic;

namespace API.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public List<StudentCourseTeacher> StudentCourseTeacher { get; set; }

    }
}
