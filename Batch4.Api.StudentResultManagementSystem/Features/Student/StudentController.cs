using Batch4.Api.StudentResultManagement.BusinessLogic.Services.Student;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Batch4.Api.StudentResultManagementSystem.Features.Student
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly BL_Student _bL_Student;

        public StudentController(BL_Student bL_Student)
        {
            _bL_Student = bL_Student;
        }

        [HttpGet]
        public IActionResult Read()
        {
            var lst = _bL_Student.GetAllStudents();
            return Ok(lst);
        }
    }
}
