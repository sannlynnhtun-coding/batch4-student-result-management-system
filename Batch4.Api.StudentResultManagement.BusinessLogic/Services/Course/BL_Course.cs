using Batch4.Api.StudentResultManagement.DataAccess.Models;
using Batch4.Api.StudentResultManagement.DataAccess.Services.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.Api.StudentResultManagement.BusinessLogic.Services.Course
{
    public class BL_Course
    {
        private readonly DA_Course _da_Course;

        public BL_Course(DA_Course course)
        {
            _da_Course = course;
        }

        public List<CourseModel> GetAllCourses()
        {
            var lst = _da_Course.GetCourses();
            return lst;
        }

        public CourseModel GetCourseById(int id)
        {
            var item = _da_Course.GetCourse(id);
            return item;
        }

        public int CreateCourse (CourseModel course)
        {
            var result = _da_Course.CreateCourse(course);
            return result;
        }
        public int UpdateCourse(int id, CourseModel course)
        {
            return _da_Course.UpdateCourse(id, course);
        }

        public int DeleteCourseById(int id)
        {
            var result = _da_Course.DeleteCourse(id);
            return result;
        }
    }
}
