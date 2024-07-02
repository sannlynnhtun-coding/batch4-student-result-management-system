using System.Data.SqlClient;

namespace Batch4.Api.StudentResultManagement.DataAccess
{
    internal static class ConnectionStrings
    {
        public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "ZACK",
            InitialCatalog = "StudentResultManagementSystem",
            UserID = "sa",
            Password = "sa@123",
            TrustServerCertificate = true,
        };

    }
}
