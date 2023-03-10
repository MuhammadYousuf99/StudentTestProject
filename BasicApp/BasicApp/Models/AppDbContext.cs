using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BasicApp.Models;

namespace BasicApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("AppDbContext")
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourseResult> StudentCourseResults { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasKey(e => e.Id);
            modelBuilder.Entity<Course>().HasKey(e => e.Id);
            modelBuilder.Entity<StudentCourseResult>().HasKey(e => e.Id);

            modelBuilder.Entity<StudentCourseResult>()
                .HasRequired(e => e.Student)
                .WithMany()
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<StudentCourseResult>()
                .HasRequired(e => e.Course)
                .WithMany()
                .HasForeignKey(e => e.CourseId);
        }
    }
}