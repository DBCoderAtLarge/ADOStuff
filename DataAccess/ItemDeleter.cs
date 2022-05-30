using System.Data;
using System.Data.SqlClient;

namespace ADOStuff.DataAccess
{
    public class ItemDeleter : IItemDeleter
    {
        private readonly IDbResolver _dbResolver;

        public ItemDeleter(IDbResolver dbResolver)
        {
            _dbResolver = dbResolver;
        }

        public bool Delete(string table, (string keyName, int key) key)
        {
            using var connection = _dbResolver.GetDbConnectionManager().GetOpenConnection();
            using var command = connection.CreateCommand();
            
            var keyParameterName = "@Key";
            command.CommandText = $"DELETE FROM {table} WHERE {key.keyName} = {keyParameterName};";

            var keyParam = new SqlParameter(keyParameterName, SqlDbType.Int) { Value = key.key };

            command.Parameters.Add(keyParam);

            return command.ExecuteNonQuery() == 1;
        }
    }
}