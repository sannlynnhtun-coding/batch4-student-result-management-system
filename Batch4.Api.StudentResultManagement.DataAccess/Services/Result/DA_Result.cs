using Batch4.Api.StudentResultManagement.DataAccess.Db;

namespace Batch4.Api.StudentResultManagement.DataAccess.Services.Result
{
    public class DA_Result
    {
        private readonly AppDbContext _context;

        public DA_Result(AppDbContext context)
        {
            _context = context;
        }
    }
}
