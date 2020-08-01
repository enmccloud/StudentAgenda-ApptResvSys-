using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Moq;
using StudentAgenda.Areas.Class.Models;
using StudentAgenda.Areas.Teacher.Controllers;
using StudentAgenda.Areas.Teacher.Models;
using StudentAgenda.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;


namespace StudentAgendaTests
{
    public class TeacherControllerTest
    {
        TeacherController systemUnderTest;
        Mock<ITeacherRepository> mockTeacherRepository;
        Mock<IClassRepository> mockClassRepository;

        public TeacherControllerTest()
        {
            mockTeacherRepository = new Mock<ITeacherRepository>();
            mockClassRepository = new Mock<IClassRepository>();
            systemUnderTest = new TeacherController(mockTeacherRepository.Object, mockClassRepository.Object);
        }

        [Fact]
        public async void IndexActionMethod_ReturnsAViewResult()
        {
            // act
            var result = await systemUnderTest.Index();

            // assert
            Assert.IsType<ViewResult>(result);
        }


        [Fact]
        public async void Index_Always_ReturnsAllRecordsFromRepository()
        {
            // arrange
            var teachers = new List<Teachers>
            {
                new Teachers(),
                new Teachers(),
                new Teachers()
            };
            mockTeacherRepository.Setup(p => p.GetAllAsync()).Returns(Task.FromResult(teachers));

            // act
            var result = await systemUnderTest.Index();

            // assert
            var temp = (ViewResult)result;
            Assert.IsAssignableFrom<IList<Teachers>>(temp.Model);
            var returnedTeacher = (IList<Teachers>)temp.Model;
            Assert.Equal(3, returnedTeacher.Count);
        }

        [Fact]
        public async void Details_WhenIdIsNull_ReturnsNotFound()
        {
            var result = await systemUnderTest.Details(null);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Details_WhenTeacherDoesNotExist_ReturnsNotFound()
        {
            mockTeacherRepository.Setup(p => p.GetByIdAsync(1)).Returns(Task.FromResult((Teachers)null));
            var result = await systemUnderTest.Details(1);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Details_WhenTeacherExists_ReturnsNotFound()
        {
            var teacher1 = new Teachers();
            var teacher2 = new Teachers();

            mockTeacherRepository.Setup(p => p.GetByIdAsync(1)).Returns(Task.FromResult(teacher1));
            mockTeacherRepository.Setup(p => p.GetByIdAsync(2)).Returns(Task.FromResult(teacher2));
            var result = await systemUnderTest.Details(1);
            Assert.IsType<ViewResult>(result);

            var temp = (ViewResult)result;
            var returnedTeacher = (Teachers)temp.Model;

            Assert.Same(teacher1, returnedTeacher);

        }

        [Fact]
        public async void Create_OnGet_PopulatesClassList()
        {
            List<Classes> classes = new List<Classes>
            {
                new Classes(),
                new Classes(),
                new Classes()
            };
            mockClassRepository.Setup(p => p.GetAllAsync()).Returns(Task.FromResult(classes));

            var result = await systemUnderTest.Create();

            Assert.IsType<ViewResult>(result);
            var temp = (ViewResult)result;
            var viewData = temp.ViewData;
            var classList = (SelectList)viewData["ClassId"];
            Assert.Equal(3, classList.Count());
        }

        [Fact]
        public async void Create_OnPost_PerformsExpectedWork()
        {
            var teacher = new Teachers();
            mockTeacherRepository.Setup(p => p.InsertAsync(teacher)).Returns(Task.FromResult(teacher));
            var result = await systemUnderTest.Create(teacher);

            mockTeacherRepository.VerifyAll();
        }

        [Fact]
        public async void EditWhenIdIsNull_ReturnsNotFound()
        {
            var result = await systemUnderTest.Edit(null);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Edit_WhenTeacherDoesNotExist_ReturnsNotFound()
        {
            mockTeacherRepository.Setup(p => p.GetByIdAsync(1)).Returns(Task.FromResult((Teachers)null));
            var result = await systemUnderTest.Edit(1);
            Assert.IsType<NotFoundResult>(result);
        }

         
        [Fact]
        public async void Edit_Always_GetPostReturnsAllRecordsFromRepository()
        {
            // arrange
            var teacher1 = new Teachers();
           
           
            mockTeacherRepository.Setup(p => p.GetByIdAsync(1)).Returns(Task.FromResult(teacher1));
            mockClassRepository.Setup(p => p.GetAllAsync()).Returns(Task.FromResult(new List<Classes>()));
            // act
            var result = await systemUnderTest.Edit(1);

            // assert
            var temp = result as ViewResult;
            Assert.NotNull(temp);
            var returnedTeacher = temp.Model;
            Assert.NotNull(returnedTeacher);
           
        }
        //Post Edit 
        [Fact]
        public async void Edit_WhenTeacherIDNotFound()
        {
            var result = await systemUnderTest.Edit(null);
            Assert.IsType<NotFoundResult>(result);
        }
    

        [Fact]
        public async void DeleteWhenIdIsNull_ReturnsNotFound()
        {
            var result = await systemUnderTest.Delete(null);
            Assert.IsType<NotFoundResult>(result);
        }

        //Get Delete
        [Fact]
        public async void Delete_WhenTeacherDoesNotExist_ReturnsNotFound()
        {
            mockTeacherRepository.Setup(p => p.GetByIdAsync(1)).Returns(Task.FromResult((Teachers)null));
            var result = await systemUnderTest.Delete(1);
            Assert.IsType<NotFoundResult>(result);
        }


    }

}





