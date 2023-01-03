using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<CourseTeacher> CourseTeacher { get; set; }
        public DbSet<StudentCourseTeacher> StudentCourseTeacher { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CourseTeacher>()
                .HasKey(k => new { k.CourseId, k.TeacherId });

            modelBuilder.Entity<CourseTeacher>()
                .HasOne(s => s.Course)
                .WithMany(l => l.CourseTeacher)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        

            modelBuilder.Entity<CourseTeacher>()
                .HasOne(s => s.Teacher)
                .WithMany(l => l.CourseTeacher)
                .HasForeignKey(s => s.TeacherId)
                .OnDelete(DeleteBehavior.NoAction);

            //-----------StudentCourseTeacher
            modelBuilder.Entity<StudentCourseTeacher>()
            .HasKey(k => new { k.StudentId,k.CourseId, k.TeacherId });

            modelBuilder.Entity<StudentCourseTeacher>()
                .HasOne(s => s.Student)
                .WithMany(l => l.StudentCourseTeacher)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<StudentCourseTeacher>()
                .HasOne(s => s.Course)
                .WithMany(l => l.StudentCourseTeacher)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentCourseTeacher>()
               .HasOne(s => s.Teacher)
               .WithMany(l => l.StudentCourseTeacher)
               .HasForeignKey(s => s.TeacherId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
    
}
