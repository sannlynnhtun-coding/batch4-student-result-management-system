using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Batch4.Api.StudentResultManagement.DataAccess.Models
{
    [Table("Tbl_Result")]
    public class ResultModel
    {
        [Key]
        public int ResultId { get; set; }
        public int RollNo { get; set; }
        public string? Subject { get; set; }
        public decimal Score { get; set; }
        public EnumStatus Status { get; set; }

        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public CourseModel Course { get; set; }

        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public StudentModel Student { get; set; }
    }
}
