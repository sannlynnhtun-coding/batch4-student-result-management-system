using Batch4.Api.StudentResultManagement.DataAccess.Services.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.Api.StudentResultManagement.BusinessLogic.Services.Result
{
    public class BL_Result
    {
        private readonly DA_Result _result;

        public BL_Result(DA_Result result)
        {
            _result = result;
        }
    }
}
