using Batch4.Api.StudentResultManagement.DataAccess.Db;
using Batch4.Api.StudentResultManagement.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Batch4.Api.StudentResultManagement.DataAccess.Query
{
    public class ResultQuery
    {
        private readonly AppDbContext _context;

        public ResultQuery(AppDbContext context)
        {
            _context = context;
        }

        public ResultResponseModel GetResultByRollNo(int rollNo, string password)
        {
            var query = ResultByRollNoAndPasswordQuery(rollNo, password);
            var result = _context.Results
                                .FromSqlRaw(query)
                                .Include(r => r.Student)
                                .Include(r => r.Course)
                                .FirstOrDefault();

            if (result == null)
                return null!;

            return new ResultResponseModel
            {
                RollNo = result.Student.RollNo,
                StudentName = result.Student.Name!,
                CourseName = result.Course.CourseName!,
                Score = result.Score,
                Status = result.Status.ToString(),
            };
        }

        public static string ResultByRollNoAndPasswordQuery(int rollNo, string password)
        {
            return $@"
                SELECT r.*, s.Name AS StudentName, c.CourseName
                FROM Tbl_Result r
                INNER JOIN Tbl_Student s ON r.StudentId = s.StudentId
                INNER JOIN Tbl_Course c ON r.CourseId = c.CourseId
                WHERE s.RollNo = {rollNo} AND s.Password = '{password}'
            ";
        }
    }
}
