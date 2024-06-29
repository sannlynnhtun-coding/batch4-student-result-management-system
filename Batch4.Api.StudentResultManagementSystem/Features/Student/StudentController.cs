﻿using Batch4.Api.StudentResultManagement.BusinessLogic.Services.Student;
using Batch4.Api.StudentResultManagement.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetStudent(int id)
        {
            var student = _bl_Student.GetStudentById(id);
            if (student == null)
            {
                return NotFound("Student not found!");
            }
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create(StudentModel student)
        {
            var result = _bl_Student.CreateStudent(student);
            string message = result > 0 ? "Saving Successful!" : "Saving Failed!";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, StudentModel student)
        {
            var result = _bl_Student.UpdateStudent(id, student);
            string message = result > 0 ? "Updating Successful!" : "Updating Failed!";
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
