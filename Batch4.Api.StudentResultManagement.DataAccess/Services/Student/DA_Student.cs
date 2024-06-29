using Batch4.Api.StudentResultManagement.DataAccess.Db;
using Batch4.Api.StudentResultManagement.DataAccess.Models;

namespace Batch4.Api.StudentResultManagement.DataAccess.Services.Student
{
    public class DA_Student
    {
        private readonly AppDbContext _context;

        public DA_Student(AppDbContext context)
        {
            _context = context;
        }

        public List<StudentModel>  GetStudents()
        {
            var lst = _context.Students.ToList();
            return lst;
        }
    }
}
