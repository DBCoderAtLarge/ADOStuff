using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace ADOStuff.DataAccess
{
    public static class DbConnectionExtensions
    {
        public static IDataReader ExecuteCommandQuery(this SqlConnection source, string query, SqlParameter[] parameters = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (string.IsNullOrWhiteSpace(query)) throw new ArgumentException(nameof(query));

            var command = new SqlCommand { Connection = source };

            if (!ReferenceEquals(parameters, null))
                command.Parameters.AddRange(parameters);

            command.CommandText = query;
            command.CommandType = CommandType.Text;

            return command.ExecuteReader();
        }

        public static async Task<IDataReader> ExecuteCommandQueryAsync(this SqlConnection source, string query, CancellationToken cancellationToken, DbParameter[] parameters = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (string.IsNullOrWhiteSpace(query)) throw new ArgumentException(nameof(query));

            var command = new SqlCommand { Connection = source };

            if (!ReferenceEquals(parameters, null))
                command.Parameters.AddRange(parameters);

            command.CommandText = query;
            command.CommandType = CommandType.Text;

            return await command.ExecuteReaderAsync(cancellationToken);
        }
    }
}
