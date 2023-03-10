using BasicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BasicApp.Controllers
{
    public class CourseController : ApiController
    {
        private readonly AppDbContext _dbContext;

        public CourseController()
        {
            _dbContext = new AppDbContext();
        }
        public CourseController(AppDbContext dbContext)
        {
            _dbContext = new AppDbContext();
        }
        [HttpPost]
        [Route("api/Course/Post")]
        public string Add(Course course)
        {
            //return "Course Added Successfully";
            if (!ModelState.IsValid)
            {
                return "Error in Course Adding";
            }

            course.Id = Guid.NewGuid();
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();

            return "Course Added Successfully";
        }
    }
}
