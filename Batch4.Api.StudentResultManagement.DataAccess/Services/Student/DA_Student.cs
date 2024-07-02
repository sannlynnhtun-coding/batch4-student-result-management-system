using Batch4.Api.StudentResultManagement.DataAccess.Db;
using Batch4.Api.StudentResultManagement.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Batch4.Api.StudentResultManagement.DataAccess.Services.Student
{
    public class DA_Student
    {
        private readonly AppDbContext _context;

        public DA_Student(AppDbContext context)
        {
            _context = context;
        }

        public List<StudentModel> GetStudents()
        {
            var lst = _context.Students.ToList();
            return lst;
        }

        public StudentResponseModel GetStudent(int id)
        {
            var item = _context.Students.FirstOrDefault(x => x.StudentId == id);

            if (item == null)
            {
                return null;
            }

            var courses = _context.StudentCourses
                .Where(sc => sc.StudentId == id)
                .Join(_context.Courses,
                      sc => sc.CourseId,
                      c => c.CourseId,
                      (sc, c) => new CourseResponseModel
                      {
                          CourseId = c.CourseId,
                          CourseName = c.CourseName
                      })
                .ToList();

            var studentResponse = new StudentResponseModel
            {
                StudentId = item.StudentId,
                RollNo = item.RollNo,
                Name = item.Name,
                GenderStatus = item.GenderStatus,
                Age = item.Age,
                DateOfBirth = item.DateOfBirth,
                UserName = item.UserName,
                Password = item.Password,
                PhoneNumber = item.PhoneNumber,
                Address = item.Address,
                Courses = courses
            };

            return studentResponse;
        }


        public int CreateStudent(StudentModel student, List<int> courseIds)
        {
            _context.Students.Add(student);
            _context.SaveChanges();

            if (courseIds != null && courseIds.Any())
            {
                var studentCourses = courseIds.Select(courseId => new StudentCourseModel
                {
                    StudentId = student.StudentId,
                    CourseId = courseId
                }).ToList();

                _context.StudentCourses.AddRange(studentCourses);
                _context.SaveChanges();
            }

            return student.StudentId;
        }


        public int UpdateStudent(StudentModel student, List<int> courseIds)
        {
            var oldStudent = _context.Students.FirstOrDefault(x => x.StudentId == student.StudentId);

            if (oldStudent == null)
                return 0;

            oldStudent.RollNo = student.RollNo;
            oldStudent.Name = student.Name;
            oldStudent.GenderStatus = student.GenderStatus;
            oldStudent.Age = student.Age;
            oldStudent.DateOfBirth = student.DateOfBirth;
            oldStudent.UserName = student.UserName;
            oldStudent.Password = student.Password;
            oldStudent.PhoneNumber = student.PhoneNumber;
            oldStudent.Address = student.Address;

            if (courseIds != null && courseIds.Any())
            {
                var studentCourses = courseIds.Select(courseId => new StudentCourseModel
                {
                    StudentId = student.StudentId,
                    CourseId = courseId
                }).ToList();

                _context.StudentCourses.AddRange(studentCourses);
            }

            return _context.SaveChanges();
        }


        public int DeleteStudent(int id)
        {
            var student = _context.Students.FirstOrDefault(x => x.StudentId == id);

            if (student == null)
                return 0;
            _context.Students.Remove(student);
            var result = _context.SaveChanges();
            return result;
        }
    }
}
