using API.Models;
using System.Collections.Generic;
using System.Linq;

namespace API.Data
{
    public static class SeedData
    {
        public static void Seed(ApplicationDbContext dbContext)
        {
            if (!dbContext.CourseTeacher.Any())
            {
                List<Course> courses = new List<Course> {
                new Course
                {
                
                   CourseName="English"
                },
                new Course
                {
                  
                   CourseName="French"
                },
                new Course
                {
                   
                   CourseName="Business Administration"
                },
                new Course
                {
                   
                   CourseName="ICDL"
                },
                new Course
                {
                   
                   CourseName="Communication skills"
                }
                };
                dbContext.AddRange(courses);
                dbContext.SaveChanges();
                //--------------------------------------
                List<Teacher> teachers = new List<Teacher> {
                new Teacher
                {
                 
                   TeacherName="Gary Cabrera"
                },
                new Teacher
                {
                   
                   TeacherName="Stacy Logan"
                },
                new Teacher
                {
                  
                   TeacherName="Priscilla Phelps"
                },
                new Teacher
                {
               
                   TeacherName="Aliza Vancea"
                },
                new Teacher
                {
                  
                   TeacherName="Belen Fox"
                },
                new Teacher
                {
                  
                   TeacherName="Yadira Mcintyre"
                },
                new Teacher
                {
                   
                   TeacherName="Grayson Stout"
                }
                };
                dbContext.AddRange(teachers);
                dbContext.SaveChanges();
                //--------------------------------------
                List<CourseTeacher> courseTeachers = new List<CourseTeacher> {
                new CourseTeacher
                {           
                   TeacherId = dbContext.Teachers.Where(r=>r.TeacherName== "Gary Cabrera").Select(x=>x.TeacherId).FirstOrDefault(),
                   CourseId=dbContext.Courses.Where(r=>r.CourseName== "English").Select(x=>x.CourseId).FirstOrDefault()
                },
                new CourseTeacher
                {
                   TeacherId = dbContext.Teachers.Where(r=>r.TeacherName== "Stacy Logan").Select(x=>x.TeacherId).FirstOrDefault(),
                   CourseId=dbContext.Courses.Where(r=>r.CourseName== "English").Select(x=>x.CourseId).FirstOrDefault()
                },
                new CourseTeacher
                {
                   TeacherId = dbContext.Teachers.Where(r=>r.TeacherName== "Priscilla Phelps").Select(x=>x.TeacherId).FirstOrDefault(),
                   CourseId=dbContext.Courses.Where(r=>r.CourseName== "English").Select(x=>x.CourseId).FirstOrDefault()
                },
                new CourseTeacher
                {
                   TeacherId = dbContext.Teachers.Where(r=>r.TeacherName== "Priscilla Phelps").Select(x=>x.TeacherId).FirstOrDefault(),
                   CourseId=dbContext.Courses.Where(r=>r.CourseName== "French").Select(x=>x.CourseId).FirstOrDefault()
                },
                new CourseTeacher
                {
                   TeacherId = dbContext.Teachers.Where(r=>r.TeacherName== "Aliza Vancea").Select(x=>x.TeacherId).FirstOrDefault(),
                   CourseId=dbContext.Courses.Where(r=>r.CourseName== "French").Select(x=>x.CourseId).FirstOrDefault()
                },
                new CourseTeacher
                {
                   TeacherId = dbContext.Teachers.Where(r=>r.TeacherName== "Gary Cabrera").Select(x=>x.TeacherId).FirstOrDefault(),
                   CourseId=dbContext.Courses.Where(r=>r.CourseName== "Business Administration").Select(x=>x.CourseId).FirstOrDefault()
                },
                new CourseTeacher
                {
                   TeacherId = dbContext.Teachers.Where(r=>r.TeacherName== "Stacy Logan").Select(x=>x.TeacherId).FirstOrDefault(),
                   CourseId=dbContext.Courses.Where(r=>r.CourseName== "Business Administration").Select(x=>x.CourseId).FirstOrDefault()
                },
                new CourseTeacher
                {
                   TeacherId = dbContext.Teachers.Where(r=>r.TeacherName== "Belen Fox").Select(x=>x.TeacherId).FirstOrDefault(),
                   CourseId=dbContext.Courses.Where(r=>r.CourseName== "ICDL").Select(x=>x.CourseId).FirstOrDefault()
                },
                new CourseTeacher
                {
                   TeacherId = dbContext.Teachers.Where(r=>r.TeacherName== "Yadira Mcintyre").Select(x=>x.TeacherId).FirstOrDefault(),
                   CourseId=dbContext.Courses.Where(r=>r.CourseName== "ICDL").Select(x=>x.CourseId).FirstOrDefault()
                },
                new CourseTeacher
                {
                   TeacherId = dbContext.Teachers.Where(r=>r.TeacherName== "Grayson Stout").Select(x=>x.TeacherId).FirstOrDefault(),
                   CourseId=dbContext.Courses.Where(r=>r.CourseName== "Communication skills").Select(x=>x.CourseId).FirstOrDefault()
                },
                new CourseTeacher
                {
                   TeacherId = dbContext.Teachers.Where(r=>r.TeacherName== "Yadira Mcintyre").Select(x=>x.TeacherId).FirstOrDefault(),
                   CourseId=dbContext.Courses.Where(r=>r.CourseName== "Communication skills").Select(x=>x.CourseId).FirstOrDefault()
                }
                };
                dbContext.AddRange(courseTeachers);
                dbContext.SaveChanges();
            }
        }
    }
}
