using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.Api.StudentResultManagement.DataAccess.Models
{
    public class StudentResponseModel
    {
        public int StudentId { get; set; }
        public int RollNo { get; set; }
        public string? Name { get; set; }
        public GenderStatus? GenderStatus { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public List<CourseResponseModel> Courses { get; set; }
    }

    public class CourseResponseModel
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
}
