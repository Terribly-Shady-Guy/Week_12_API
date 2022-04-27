using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week11_G4_API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Week11_G4_APITests;

namespace Week11_G4_API.Controllers.Tests
{
    [TestClass()]
    public class StudentsControllerTests
    {
        [TestMethod()]
        public void GetStudentNotFoundTest()
        {
            var controller = new StudentsController(TestDbContextCreator.CreateContext());

            var students = controller.GetStudent("S008").Result;
            Assert.IsInstanceOfType(students.Result, typeof(NotFoundResult));
        }

        [TestMethod()]
        public void GetStudentFoundTest()
        {
            var controller = new StudentsController(TestDbContextCreator.CreateContext());

            var students = controller.GetStudent("S007").Result;
            Assert.IsNotNull(students.Value);
        }

        [TestMethod()]
        public void GetStudentsTest()
        {
            var controller = new StudentsController(TestDbContextCreator.CreateContext());
            var students = controller.GetStudents().Result;

            Assert.IsNotNull(students.Value);
        }
    }
}