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

        public List<StudentModel> GetStudents()
        {
            var lst = _context.Students.ToList();
            return lst;
        }

        public StudentModel GetStudent(int id)
        {
            var item = _context.Students.FirstOrDefault(x => x.StudentId == id);
            return item!;
        }

        public int CreateStudent(StudentModel student)
        {
            _context.Students.Add(student);
            var result = _context.SaveChanges();
            return result;

        }

        public int UpdateStudent(int id, StudentModel student)
        {
            var existingStudent = _context.Students.FirstOrDefault(s => s.StudentId == id);
            if (existingStudent == null)
            {
                return 0;
            }

            existingStudent.RollNo = student.RollNo;
            existingStudent.Name = student.Name;
            existingStudent.GenderStatus = student.GenderStatus;
            existingStudent.Age = student.Age;
            existingStudent.DateOfBirth = student.DateOfBirth;
            existingStudent.UserName = student.UserName;
            existingStudent.Password = student.Password;
            existingStudent.PhoneNumber = student.PhoneNumber;
            existingStudent.Address = student.Address;

            var result = _context.SaveChanges();
            return result;
        }

        public int DeleteStudent(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.StudentId == id);
            if (student == null)
            {
                return 0;
            }

            _context.Students.Remove(student);
            var result = _context.SaveChanges();
            return result;
        }
    }
}
