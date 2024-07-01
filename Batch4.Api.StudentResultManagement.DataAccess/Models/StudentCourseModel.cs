using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.Api.StudentResultManagement.DataAccess.Models;

[Table("Tbl_StudentCourse")]
public class StudentCourseModel
{
    [Key]
    public int StudentCourseId { get; set; }

    public int StudentId { get; set; }

    public int CourseId { get; set; }
}

