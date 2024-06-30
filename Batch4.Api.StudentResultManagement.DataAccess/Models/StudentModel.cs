using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Batch4.Api.StudentResultManagement.DataAccess.Models.StudentCourseModel;

namespace Batch4.Api.StudentResultManagement.DataAccess.Models
{
    [Table("Tbl_Student")]
    public class StudentModel
    {
        [Key]
        public int StudentId { get; set; }
        public int RollNo { get; set; }
        public string? Name { get; set; }
        public GenderStatus? GenderStatus { get; set; } = null;
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }

        public List<StudentCourseModel> StudentCourses { get; set; } 
        public List<ResultModel>? Results { get; set; } 

    }
}
