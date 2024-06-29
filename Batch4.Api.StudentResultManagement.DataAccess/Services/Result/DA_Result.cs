using Batch4.Api.StudentResultManagement.DataAccess.Db;
using Batch4.Api.StudentResultManagement.DataAccess.Models;

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
            var results = _context.Results.ToList();
            return results;
        }

        public ResultModel GetResultById(int id)
        {
            var result = _context.Results.FirstOrDefault(r => r.ResultId == id);
            return result!;
        }

        public int CreateResult(ResultModel result)
        {
            _context.Results.Add(result);
            var resultCount = _context.SaveChanges();
            return resultCount;
        }

        public int UpdateResult(int id, ResultModel result)
        {
            var existingResult = _context.Results.FirstOrDefault(r => r.ResultId == id);
            if (existingResult == null)
            {
                return 0;
            }

            existingResult.RollNo = result.RollNo;
            existingResult.Subject = result.Subject;
            existingResult.Score = result.Score;
            existingResult.Status = result.Status;
            existingResult.CourseId = result.CourseId;
            existingResult.StudentId = result.StudentId;

            var resultCount = _context.SaveChanges();
            return resultCount;
        }

        public int DeleteResult(int id)
        {
            var result = _context.Results.FirstOrDefault(r => r.ResultId == id);
            if (result == null)
            {
                return 0;
            }

            _context.Results.Remove(result);
            var resultCount = _context.SaveChanges();
            return resultCount;
        }
    }
}
