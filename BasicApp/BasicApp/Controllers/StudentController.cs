using System;
using System.Linq;
using System.Web.Http;
using BasicApp.Models;

namespace BasicApp.Controllers
{
    public class StudentController : ApiController
    {
        private readonly AppDbContext _dbContext;

        public StudentController()
        {
            _dbContext = new AppDbContext();
        }
        public StudentController(AppDbContext dbContext)
        {
            _dbContext = new AppDbContext();
        }

        [HttpPost]
        [Route("api/Student/Post")]
        public string Add(Student student)
        {
            if (!ModelState.IsValid)
            {
                return "Error in Student Data Submitting";
            }

            student.Id = Guid.NewGuid();
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();

            return "Student Added Successfully";
        }

        [HttpPut]
        [Route("api/Student/Put")]
        public string Update(Student student)
        {
            if (!ModelState.IsValid)
            {
                return "Error in Student Data Updating";
            }

            var existingStudent = _dbContext.Students.FirstOrDefault(s => s.Id == student.Id);

            if (existingStudent == null)
            {
                return "Student not found for the given id";
            }

            existingStudent.FullName = student.FullName;
            _dbContext.SaveChanges();

            return "Student Updated Successfully";
        }
    }
}
