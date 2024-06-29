using Batch4.Api.StudentResultManagement.BusinessLogic.Services.Result;
using Batch4.Api.StudentResultManagement.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("rollno/{rollNo}/course/{courseId}")]
        public IActionResult GetResultByRollNoAndCourseId(int rollNo, int courseId)
        {
            var result = _bl_Result.GetResultByRollNoAndCourseId(rollNo, courseId);
            if (result == null)
            {
                return NotFound("No result found for the given roll number and course.");
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(ResultModel result)
        {
            var resultCount = _bl_Result.CreateResult(result);
            string message = resultCount > 0 ? "Saving Successful!" : "Saving Failed!";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ResultModel result)
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
