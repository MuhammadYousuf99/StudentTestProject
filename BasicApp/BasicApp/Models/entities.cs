using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicApp.Models
{
    public class entities
    {
    }
    public class Student
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        [RegularExpression(@"^[a-zA-Z]+ [a-zA-Z]+ [a-zA-Z]+$", ErrorMessage = "Invalid full name format")]
        public string FullName { get; set; }
    }

    public class Course
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Invalid name format")]
        public string Name { get; set; }
    }

    public class StudentCourseResult
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Student ID is required")]
        public Guid StudentId { get; set; }


        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }


        [Required(ErrorMessage = "Course ID is required")]
        public Guid CourseId { get; set; }


        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }


        [Required(ErrorMessage = "Date time is required")]
        public DateTime DateTime { get; set; }

        [Range(0, 100, ErrorMessage = "Score must be between 0 and 100")]
        public decimal Score { get; set; }
    }
}