using System.Data.SqlClient;

namespace ADOStuff.DataAccess
{
    public interface ISqlDbConnectionManager
    {
        SqlConnection GetOpenConnection();
    }
}
