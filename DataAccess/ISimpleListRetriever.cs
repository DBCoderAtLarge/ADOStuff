using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace ADOStuff.DataAccess
{
    public interface ISimpleListRetriever
    {
        IEnumerable<ISimpleListItem> GetSimpleList(
            string query,
            SqlParameter[] parameters = null,
            bool? withNullCheck = null
        );

        Task<IEnumerable<ISimpleListItem>> GetSimpleListAsync(
            string query,
            CancellationToken cancellationToken,
            SqlParameter[] parameters = null,
            bool? withNullCheck = null
            );
    }
}