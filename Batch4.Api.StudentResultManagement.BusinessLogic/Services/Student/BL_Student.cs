using Batch4.Api.StudentResultManagement.DataAccess.Models;
using Batch4.Api.StudentResultManagement.DataAccess.Services.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.Api.StudentResultManagement.BusinessLogic.Services.Student
{
    public class BL_Student
    {
        private readonly DA_Student _da_Student;

        public BL_Student(DA_Student student)
        {
            _da_Student = student;
        }

        public List<StudentModel> GetAllStudents()
        {
            var lst = _da_Student.GetStudents();
            return lst;
        }

        public StudentModel GetStudentById(int id)
        {
            var student = _da_Student.GetStudent(id);
            return student;
        }

        public int CreateStudent(StudentModel student)
        {
            var result = _da_Student.CreateStudent(student);
            return result;
        }

        public int UpdateStudent(int id, StudentModel student)
        {
            var result = _da_Student.UpdateStudent(id, student);
            return result;
        }

        public int DeleteStudent(int id)
        {
            var result = _da_Student.DeleteStudent(id);
            return result;
        }
    }
}
