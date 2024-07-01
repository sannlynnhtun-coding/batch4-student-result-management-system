using Batch4.Api.StudentResultManagement.BusinessLogic.Services;
using Batch4.Api.StudentResultManagement.BusinessLogic.Services.Result;
using Batch4.Api.StudentResultManagement.DataAccess.Db;
using Batch4.Api.StudentResultManagement.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Batch4.Api.StudentResultManagementSystem.Features.Result
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly BL_Result _bl_Result;

        public ResultController(BL_Result bl_Result)
        {
            _bl_Result = bl_Result;
        }

        [HttpGet]
        public IActionResult GetResults()
        {
            var results = _bl_Result.GetAllResults();
            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetResult(int id)
        {
            var result = _bl_Result.GetResultById(id);
            if (result == null)
            {
                return NotFound("Result not found!");
            }
            return Ok(result);
        }

        [HttpGet("rollNo")]
        public IActionResult GetResultByRollNo(int rollNo, string password)
        {
            var result = _bl_Result.GetResultByRollNo(rollNo, password);

            if (result == null)
            {
                return NotFound("Result not found for the provided credentials.");
            }

            var resultResponseModel = new ResultResponseModel
            {
                RollNo = result.Student.RollNo,
                StudentName = result.Student?.Name ?? "Unknown",
                CourseName = result.Course?.CourseName ?? "Unknown",
                Score = result.Score,
                Status = result.Status.ToString()
            };

            return Ok(resultResponseModel);
        }


        [HttpPost]
        public IActionResult Create(ResultCreateRequest resultCreateRequest)
        {
            var resultCount = _bl_Result.CreateResult(resultCreateRequest)!;
            string message = resultCount > 0 ? "Saving Successful!" : "Saving Failed!";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ResultCreateRequest result)
        {
            var resultCount = _bl_Result.UpdateResult(id, result);
            string message = resultCount > 0 ? "Updating Successful!" : "Updating Failed!";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteResult(int id)
        {
            var resultCount = _bl_Result.DeleteResult(id);
            string message = resultCount > 0 ? "Deleting Successful!" : "Deleting Failed!";
            return Ok(message);
        }
    }
}
