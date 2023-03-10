using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BasicApp.Models;

namespace BasicApp.Models
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            base.Seed(context);

            var course = new List<Course> {
                new Course {Name="Yousuf" },
                                new Course {Name= "Ali" }
            };

            var student = new List<Student> {
                new Student {FullName="Yousuf" },
                                new Student {FullName= "Ali" }
            };
            var results = new List<StudentCourseResult>
            {

                new StudentCourseResult
                {
                    Student = student[1],
                    Course = course[1],
                    DateTime = DateTime.Now,
                    Score = 90
                }
            };
            context.StudentCourseResults.AddRange(results);

            context.SaveChanges();
        }

    }
}