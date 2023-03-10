using BasicApp.Controllers;
using BasicApp.Models;
using Moq;
using NUnit.Framework;
using System.Web.Http.Results;

namespace BasicApp.Tests
{
    [TestFixture]
    public class CourseControllerTests
    {
        private CourseController _controller;
        private Mock<AppDbContext> _dbMock;

        [SetUp]
        public void SetUp()
        {
            _dbMock = new Mock<AppDbContext>();
            _controller = new CourseController(_dbMock.Object);
        }
        [Test]
        public void AddCourse_ShouldReturnBadRequest_WhenModelStateIsInvalid()
        {
            _controller.ModelState.AddModelError("Name", "Required");

            var result = _controller.Add(new Course());

            Assert.IsInstanceOf<BadRequestErrorMessageResult>(result);
            _dbMock.Verify(d => d.SaveChanges(), Times.Never);
        }
    }



}