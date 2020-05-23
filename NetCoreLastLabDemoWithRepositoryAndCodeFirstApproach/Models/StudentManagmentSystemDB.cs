using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLastLabDemoWithRepositoryAndCodeFirstApproach.Models
{
    public class StudentManagmentSystemDB : DbContext
    {
        public StudentManagmentSystemDB(DbContextOptions<StudentManagmentSystemDB> options) : base(options)

        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Department> Department { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>().HasKey(ba => new { ba.CourseId, ba.StudentId });
          
  
        }

    }
   

}
