using Batch4.Api.StudentResultManagement.DataAccess.Db;
using Batch4.Api.StudentResultManagement.DataAccess.Models;

namespace Batch4.Api.StudentResultManagement.DataAccess.Services.Course
{
    public class DA_Course
    {
        private readonly AppDbContext _context;

        public DA_Course(AppDbContext context)
        {
            _context = context;
        }

        public List<CourseModel> GetCourses()
        {
            var lst = _context.Courses.ToList();
            return lst;
        }
        public CourseModel GetCourse(int id)
        {
            var item = _context.Courses.FirstOrDefault(x =>x.CourseId == id);
            return item!;
        }
    }
}
