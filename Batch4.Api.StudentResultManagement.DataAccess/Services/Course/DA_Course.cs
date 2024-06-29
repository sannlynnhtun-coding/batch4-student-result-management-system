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
            var item = _context.Courses.FirstOrDefault(x => x.CourseId == id);
            return item!;
        }

        public int CreateCourse(CourseModel requestModel)
        {
            _context.Courses.Add(requestModel);
            var result = _context.SaveChanges();
            return result;
        }

        public int UpdateCourse(int id, CourseModel requestModel)
        {
            var item = _context.Courses.FirstOrDefault(x => x.CourseId == id);
            if (item == null)
            {
                return 0;
            }
            item.CourseName = requestModel.CourseName;
            item.Duration = requestModel.Duration;
            item.Charges = requestModel.Charges;
            item.Description = requestModel.Description;

            return _context.SaveChanges();
        }

        public int DeleteCourse(int id)
        {
            var item = _context.Courses.FirstOrDefault(x => x.CourseId == id);
            if (item == null)
            {
                return 0;
            }
            _context.Courses.Remove(item);
            var result = _context.SaveChanges();
            return result;
        }
    }
}
