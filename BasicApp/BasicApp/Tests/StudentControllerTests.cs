using System;
using BasicApp.Controllers;
using BasicApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicApp.Tests
{
    [TestClass]
    public class StudentControllerTests
    {
        private readonly AppDbContext _dbContext;
        private readonly StudentController _controller;

        public StudentControllerTests()
        {
            _dbContext = new AppDbContext();
            _controller = new StudentController(_dbContext);
        }

        [TestMethod]
        public void Add_WithValidData_ShouldReturnSuccessMessage()
        {
            // Arrange
            var student = new Student
            {
                FullName = "John Doe Smith"
            };

            // Act
            var result = _controller.Add(student);

            // Assert
            Assert.AreEqual("Student Added Successfully", result);
        }

        [TestMethod]
        public void Add_WithInvalidData_ShouldReturnErrorMessage()
        {
            // Arrange
            var student = new Student
            {
                FullName = "John"
            };

            // Act
            var result = _controller.Add(student);

            // Assert
            Assert.AreEqual("Error in Student Data Submitting", result);
        }

        [TestMethod]
        public void Update_WithValidData_ShouldReturnSuccessMessage()
        {
            // Arrange
            var student = new Student
            {
                Id = Guid.NewGuid(),
                FullName = "John Doe Smith"
            };
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();

            var updatedStudent = new Student
            {
                Id = student.Id,
                FullName = "John Smith"
            };

            // Act
            var result = _controller.Update(updatedStudent);

            // Assert
            Assert.AreEqual("Student Updated Successfully", result);
            Assert.AreEqual("John Smith", _dbContext.Students.Find(student.Id).FullName);
        }

        [TestMethod]
        public void Update_WithInvalidData_ShouldReturnErrorMessage()
        {
            // Arrange
            var student = new Student
            {
                Id = Guid.NewGuid(),
                FullName = "John Doe Smith"
            };
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();

            var updatedStudent = new Student
            {
                Id = student.Id,
                FullName = "John"
            };

            // Act
            var result = _controller.Update(updatedStudent);

            // Assert
            Assert.AreEqual("Error in Student Data Updating", result);
            Assert.AreEqual("John Doe Smith", _dbContext.Students.Find(student.Id).FullName);
        }

        [TestMethod]
        public void Update_WithNonExistingStudent_ShouldReturnErrorMessage()
        {
            // Arrange
            var student = new Student
            {
                Id = Guid.NewGuid(),
                FullName = "John Doe Smith"
            };
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();

            var updatedStudent = new Student
            {
                Id = Guid.NewGuid(),
                FullName = "John Smith"
            };

            // Act
            var result = _controller.Update(updatedStudent);

            // Assert
            Assert.AreEqual("Student not found for the given id", result);
            Assert.AreEqual("John Doe Smith", _dbContext.Students.Find(student.Id).FullName);
        }
    }
}
