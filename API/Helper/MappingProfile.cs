using API.DTOs;
using API.Models;
using AutoMapper;
using System.Linq;

namespace API.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {         
           CreateMap<RegisterStudentDto, StudentCourseTeacher>().
              ForPath(d => d.Student.StudentName, o => o.MapFrom(s => s.StudentName))
             .ForPath(d => d.TeacherId, o => o.MapFrom(s => s.TeacherId))
             .ForPath(d => d.CourseId, o => o.MapFrom(s => s.CourseId));

            CreateMap<UpdateStudentDto, StudentCourseTeacher>()            
            .ForPath(d => d.TeacherId, o => o.MapFrom(s => s.TeacherId))
            .ForPath(d => d.CourseId, o => o.MapFrom(s => s.CourseId));
           // CreateMap<UpdateStudentDto, Student>().ReverseMap();
      
            CreateMap<CourseTeacher, TeacherDto>().
                 ForMember(d => d.TeacherName, o => o.MapFrom(s => s.Teacher.TeacherName));
               
            CreateMap<Course, CourseTeachersDto>().
             ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName))
            .ForMember(d => d.Teachers, o => o.MapFrom(s => s.CourseTeacher));

            CreateMap<StudentCourseTeacher, CourseDto>().
           ForMember(d => d.CourseName, o => o.MapFrom(s => s.Course.CourseName));
            CreateMap<StudentCourseTeacher, TeacherDto>().
          ForMember(d => d.TeacherName, o => o.MapFrom(s => s.Teacher.TeacherName));
            CreateMap<Student, StudentCourseTeacherDto>().
            ForMember(d => d.StudentName, o => o.MapFrom(s => s.StudentName)).
            ForMember(d => d.Courses, o => o.MapFrom(s => s.StudentCourseTeacher)).
            ForMember(d => d.Teachers, o => o.MapFrom(s => s.StudentCourseTeacher));
            










        } 
    }
}
