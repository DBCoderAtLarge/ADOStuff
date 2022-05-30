namespace ADOStuff.DataAccess
{
    public class RowCounter : IRowCounter
    {
        private readonly IDbResolver _dbResolver;

        public RowCounter(IDbResolver dbResolver)
        {
            _dbResolver = dbResolver;
        }

        public int CountRows(string table)
        {
            using var connection = _dbResolver.GetDbConnectionManager().GetOpenConnection();
            using var command = connection.CreateCommand();
            
            if (!Guard.WhiteList.Contains(table))
                return -1; // throw new Exception ... 

            command.CommandText = $"SELECT COUNT(*) FROM {table};";

            return (int)command.ExecuteScalar();
        }
    }
}