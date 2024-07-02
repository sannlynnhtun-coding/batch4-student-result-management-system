using Batch4.Api.StudentResultManagement.BusinessLogic.Services.Student;
using Batch4.Api.StudentResultManagement.DataAccess.Db;
using Batch4.Api.StudentResultManagement.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Batch4.Api.StudentResultManagementSystem.Features.Student
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly BL_Student _bl_Student;

        public StudentController(BL_Student bL_Student)
        {
            _bl_Student = bL_Student;
        }

        [HttpGet]
        public IActionResult Read()
        {
            var lst = _bl_Student.GetAllStudents();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var item = _bl_Student.GetStudentById(id);
                
            return Ok(item);
        }


        [HttpPost]
        public IActionResult Create(StudentCreateRequest studentCreateRequest)
        {
            var result = _bl_Student.CreateStudent(studentCreateRequest.Student,studentCreateRequest.CourseIds);
            string message = result > 0 ? "Saving Successful!" : "Saving Failed!";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,StudentCreateRequest request)
        {
            request.Student.StudentId = id;
            var result = _bl_Student.UpdateStudent(request.Student, request.CourseIds);
            string message = result > 0 ? "Update Successful!" : "Update Failed!";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var result = _bl_Student.DeleteStudent(id);
            string message = result > 0 ? "Deleting Successful!" : "Deleting Failed!";
            return Ok(message);
        }

    }
}
