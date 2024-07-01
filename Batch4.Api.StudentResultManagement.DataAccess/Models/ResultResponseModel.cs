using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.Api.StudentResultManagement.DataAccess.Models
{
    public class ResultResponseModel
    {
        public int RollNo { get; set; }
        public string? StudentName { get; set; }
        public string? CourseName { get; set; }
        public decimal Score { get; set; }
        public string? Status { get; set; }
    }
}
