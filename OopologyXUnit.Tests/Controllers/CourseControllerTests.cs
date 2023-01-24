using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oopology.Controllers;

namespace OopologyXUnit.Tests.Controllers
{
    public class CourseControllerTests
    {
        [Fact]

        public void Should_Count_Four_Courses()
        {
            //arrange
            var mock = new CourseListMocks();

            //act
            var actual = mock.ListCourses();

            //assert

            var result = 4;
            Assert.Equal(result, actual.Count());
        }

        [Fact]

        public void Should_Return_First_Course_In_List()
        {
            //arrange
            var mock = new CourseListMocks();

            //act
            var list = mock.ListCourses();
            var actual = list.First();
            //assert

            var expected = "Oopology 101: First Steps to a New Life";
            Assert.Equal(expected, actual.Title);
        }

        [Fact]

        public void Testing_Course_Controller_Index_Lists_All_Courses()
        {
            //arrange
            var mock = new CourseListMocks();

            var courseController = new CoursesController();

        }
}

    // GET: Courses
    //public async Task<IActionResult> Index()
    //{
    //    return _context.Course != null ?
    //        View(await _context.Course.ToListAsync()) :
    //        Problem("Entity set 'OopologyContext.Course'  is null.");
    //}
}
