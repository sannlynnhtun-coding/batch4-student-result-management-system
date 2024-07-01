using Batch4.Api.StudentResultManagement.DataAccess.Db;
using Batch4.Api.StudentResultManagement.DataAccess.Models;
using Batch4.Api.StudentResultManagement.DataAccess.Query;
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
        private readonly DA_Result _da_Result;

        public BL_Result(DA_Result result)
        {
            _da_Result = result;
        }

        public List<ResultModel> GetAllResults()
        {
            var results = _da_Result.GetResults();
            return results;
        }

        public ResultModel GetResultById(int id)
        {
            var result = _da_Result.GetResultById(id);
            return result;
        }

        public ResultModel GetResultByRollNo(int rollNo, string password)
        {
            return _da_Result.GetResultByRollNo(rollNo, password);
        }

        public int CreateResult(ResultCreateRequest result)
        {
            var resultCount = _da_Result.CreateResult(result);
            return resultCount;
        }

        public int UpdateResult(int id, ResultCreateRequest resultCreateRequest)
        {
            var resultModel = new ResultModel
            {
                Score = resultCreateRequest.Score,
                Status = resultCreateRequest.Status,
                StudentId = resultCreateRequest.StudentId,
                CourseId = resultCreateRequest.CourseId
            };

            return _da_Result.UpdateResult(id, resultModel);
        }


        public int DeleteResult(int id)
        {
            var resultCount = _da_Result.DeleteResult(id);
            return resultCount;
        }
    }
}
