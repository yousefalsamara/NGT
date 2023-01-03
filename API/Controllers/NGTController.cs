using API.Data;
using API.DTOs;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NGTController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public NGTController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("CourseWithTeacher")]
        public async Task<ActionResult<List<CourseTeachersDto>>> GetCourseWithTeacher()
        {
            var result = await _context.Courses.Include(c => c.CourseTeacher).ThenInclude(c => c.Teacher).ToListAsync();

            
            return _mapper.Map<List<CourseTeachersDto>>(result); ;

        }
        [HttpGet("StudentId")]
        public async Task<ActionResult<StudentCourseTeacherDto>> GetStudentDetails(int StudentId)
        {
            var result = await _context.Students.Include(c => c.StudentCourseTeacher)
                .ThenInclude(c => c.Teacher).Include(c => c.StudentCourseTeacher).ThenInclude(c => c.Course)
                .FirstOrDefaultAsync(c=>c.StudentId==StudentId);


            return _mapper.Map<StudentCourseTeacherDto>(result);

        }
        [HttpGet("StudentWithCourseWithTeacher")]
        public async Task<ActionResult<List<StudentCourseTeacherDto>>> GetStudentWithCourseWithTeacher()
        {
            var result = await _context.Students.Include(c => c.StudentCourseTeacher).ThenInclude(c => c.Teacher).Include(c=>c.StudentCourseTeacher).ThenInclude(c=>c.Course).ToListAsync();


            return _mapper.Map<List<StudentCourseTeacherDto>>(result);

        }
        [HttpPost("RegisterStudent")]
        public async Task<IActionResult>  RegisterStudent(RegisterStudentDto std)
        {
                      

            var newStudent = _mapper.Map< RegisterStudentDto , StudentCourseTeacher>(std);
           

          _context.Add(newStudent);
          await _context.SaveChangesAsync();
          return Ok(201);
            //return CreatedAtRoute("GetOrder", new { id = order.Id }, order.Id);

        }
        [HttpPut("{StudentId}")]
        public async Task<IActionResult> UpdateStudent(int StudentId, UpdateStudentDto std)
        {

            var existStudent = _context.StudentCourseTeacher.Include(s => s.Student).Include(s => s.Teacher).Include(s => s.Course).FirstOrDefault(s => s.StudentId == StudentId);
            if (existStudent == null)
                return NotFound("The Student Not Exist");

            _context.Remove(existStudent);
            await _context.SaveChangesAsync();
            std.StudentId = StudentId;
            var newStudent = _mapper.Map<UpdateStudentDto, StudentCourseTeacher>(std);
            var updateStudent = new Student
            {
                StudentId = std.StudentId,
                StudentName = std.StudentName ?? existStudent.Student.StudentName
            };
            _context.Update(updateStudent);
            _context.StudentCourseTeacher.Add(newStudent);
            await _context.SaveChangesAsync();
            return Ok();
            

        }
    }
}
