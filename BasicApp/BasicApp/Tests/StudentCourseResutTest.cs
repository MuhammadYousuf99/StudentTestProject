using BasicApp.Controllers;
using BasicApp.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Web.Http.Results;

namespace BasicApp.Tests
{
    [TestFixture]
    public class StudentCourseResutTest
    {
        private StudentCourseResultController _controller;
        private Mock<AppDbContext> _dbMock;

        [SetUp]
        public void SetUp()
        {
            _dbMock = new Mock<AppDbContext>();
            _controller = new StudentCourseResultController (_dbMock.Object );
        }

        [Test]
        public void AddResult_ShouldReturnOk()
        {
            var result = new StudentCourseResult
            {
                StudentId = Guid.NewGuid(),
                CourseId = Guid.NewGuid(),
                DateTime = DateTime.Now,
                Score = 85
            };

            var apiResult = _controller.AddResult(result);

            Assert.IsInstanceOf<OkNegotiatedContentResult<StudentCourseResult>>(apiResult);
            _dbMock.Verify(d => d.SaveChanges(), Times.Once);
        }

        [Test]
        public void AddResult_ShouldReturnBadRequest_WhenModelStateIsInvalid()
        {
            _controller.ModelState.AddModelError("StudentId", "Required");

            var apiResult = _controller.AddResult(new StudentCourseResult());

            Assert.IsInstanceOf<BadRequestErrorMessageResult>(apiResult);
            _dbMock.Verify(d => d.SaveChanges(), Times.Never);
        }

        [Test]
        public void UpdateResult_ShouldReturnOk()
        {
            var result = new StudentCourseResult
            {
                Id = Guid.NewGuid(),
                StudentId = Guid.NewGuid(),
                CourseId = Guid.NewGuid(),
                DateTime = DateTime.Now,
                Score = 90
            };

            var apiResult = _controller.UpdateResult(result);

            Assert.IsInstanceOf<OkNegotiatedContentResult<StudentCourseResult>>(apiResult);
            _dbMock.Verify(d => d.SaveChanges(), Times.Once);
        }


        [Test]
        public void UpdateResult_ShouldReturnBadRequest_WhenModelStateIsInvalid()
        {
            _controller.ModelState.AddModelError("StudentId", "Required");

            var apiResult = _controller.UpdateResult(new StudentCourseResult());

            Assert.IsInstanceOf<BadRequestErrorMessageResult>(apiResult);
            _dbMock.Verify(d => d.SaveChanges(), Times.Never);
        }



    }
}