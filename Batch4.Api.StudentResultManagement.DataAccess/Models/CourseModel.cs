using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Batch4.Api.StudentResultManagement.DataAccess.Models.StudentCourseModel;

namespace Batch4.Api.StudentResultManagement.DataAccess.Models
{
    [Table("Tbl_Course")]
    public class CourseModel
    {
        [Key]
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public string? Duration { get; set; }
        public decimal Charges { get; set; }
        public string? Description { get; set; }

        public ICollection<StudentCourseModel> StudentCourses { get; set; } = new List<StudentCourseModel>();
        public ICollection<ResultModel> Results { get; set; } = new List<ResultModel>();

    }
}
