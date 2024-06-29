using Batch4.Api.StudentResultManagement.BusinessLogic.Services.Course;
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
    }
}
