using System;
using System.Linq;
using System.Web.Http;
using BasicApp.Models;



namespace BasicApp.Controllers
{
    public class StudentCourseResultController : ApiController
    {
        private readonly AppDbContext _dbContext;

        public StudentCourseResultController()
        {
            _dbContext = new AppDbContext();
        }
        public StudentCourseResultController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("api/StudentCourseResult/Post")]
        public string AddResult(StudentCourseResult result)
        {
            if (!ModelState.IsValid)
            {
                return "Error in Student Result Submitting";
            }

            result.Id = Guid.NewGuid();
            _dbContext.StudentCourseResults.Add(result);
            _dbContext.SaveChanges();

            return "Student Result Submitting Successfully";
        }
        [HttpPut]
        [Route("api/StudentCourseResult/Put")]
        public string UpdateResult(StudentCourseResult result)
        {
            if (!ModelState.IsValid)
            {
                return "Error in Student Result Updating";
            }

            var existingResult = _dbContext.StudentCourseResults.FirstOrDefault(r => r.Id == result.Id);

            if (existingResult == null)
            {
                return "Student Result not found for the given id";
            }

            existingResult.StudentId = result.StudentId;
            existingResult.CourseId = result.CourseId;
            existingResult.DateTime = result.DateTime;
            existingResult.Score = result.Score;

            _dbContext.SaveChanges();

            return "Student Result Updated Successfully";
        }
    }
}
