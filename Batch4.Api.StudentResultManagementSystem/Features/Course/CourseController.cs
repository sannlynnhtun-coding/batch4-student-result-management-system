using Batch4.Api.StudentResultManagement.BusinessLogic.Services.Course;
using Batch4.Api.StudentResultManagement.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Batch4.Api.StudentResultManagementSystem.Features.Course
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly BL_Course _bl_Course;

        public CourseController(BL_Course bl_Course)
        {
            _bl_Course = bl_Course;
        }

        [HttpGet]
        public IActionResult GetCourses()
        {
            var lst = _bl_Course.GetAllCourses();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetCourse(int id)
        {
            var item = _bl_Course.GetCourseById(id);
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(CourseModel course)
        {
            var result = _bl_Course.CreateCourse(course);
            string message = result > 0 ? "Saving Successful!" : "Saving Failed!";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,CourseModel course)
        {
            var item = _bl_Course.GetCourseById(id);
            if (item == null)
            {
                return NotFound("Course not found!");
            }
            var result = _bl_Course.UpdateCourse(id, course);
            string message = result > 0 ? "Updating Successful!" : "Updating Failed!";
            return Ok(message);
        }

        [HttpDelete]
        public IActionResult DeleteCourse(int id)
        {
            var item = _bl_Course.GetCourseById(id);
            if (item is null)
            {
                return NotFound("No data found!");
            }
            var result = _bl_Course.DeleteCourseById(id);
            string message = result > 0 ? "Deleting Successful!" : "Deleting Failed!";
            return Ok(message);
        }
    }
}
