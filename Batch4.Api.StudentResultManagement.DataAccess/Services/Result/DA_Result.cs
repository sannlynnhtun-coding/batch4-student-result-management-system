using Batch4.Api.StudentResultManagement.DataAccess.Db;
using Batch4.Api.StudentResultManagement.DataAccess.Models;
using Batch4.Api.StudentResultManagement.DataAccess.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Batch4.Api.StudentResultManagement.DataAccess.Services.Result
{
    public class DA_Result
    {
        private readonly AppDbContext _context;

        public DA_Result(AppDbContext context)
        {
            _context = context;
        }

        public List<ResultModel> GetResults()
        {
            var results = _context.Results
                .Include(r => r.Student)  
                .Include(r => r.Course)   
                .ToList();

            return results;
        }

        public ResultModel GetResultByRollNo(int rollNo, string password)
        {
            var query = ResultQuery.ResultByRollNoAndPasswordQuery(rollNo, password);
            var result = _context.Results
                                 .FromSqlRaw(query)
                                 .Include(r => r.Student)
                                 .Include(r => r.Course)
                                 .FirstOrDefault();
            return result;
        }

        public ResultModel GetResultById(int id)
        {
            var result = _context.Results
                .Include(r => r.Student)
                .Include(r => r.Course)
                .FirstOrDefault(r => r.ResultId == id);

            return result!;
        }

        public int CreateResult(ResultCreateRequest resultCreateRequest)
        {
            var existingStudent = _context.Students.FirstOrDefault(s => s.StudentId == resultCreateRequest.StudentId);
            var existingCourse = _context.Courses.FirstOrDefault(c => c.CourseId == resultCreateRequest.CourseId);

            if (existingStudent == null || existingCourse == null)
            {
                return 0;
            }

            var result = new ResultModel
            {
                Score = resultCreateRequest.Score,
                Status = resultCreateRequest.Status,
                StudentId = resultCreateRequest.StudentId,
                CourseId = resultCreateRequest.CourseId
            };

            _context.Results.Add(result);
            return _context.SaveChanges();
        }



        public int UpdateResult(int id, ResultModel resultModel)
        {
            var existingResult = _context.Results.FirstOrDefault(r => r.ResultId == id);
            if (existingResult == null)
            {
                return 0;
            }

            existingResult.Score = resultModel.Score;
            existingResult.Status = resultModel.Status;
            existingResult.StudentId = resultModel.StudentId;
            existingResult.CourseId = resultModel.CourseId;

            var resultCount = _context.SaveChanges();
            return resultCount;
        }


        public int DeleteResult(int id)
        {
            var result = _context.Results.FirstOrDefault(r => r.ResultId == id);
            if (result == null)
                return 0;

            _context.Results.Remove(result);
            return _context.SaveChanges();
        }
    }
}
