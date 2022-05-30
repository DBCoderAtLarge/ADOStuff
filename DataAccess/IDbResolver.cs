namespace ADOStuff.DataAccess
{
    public interface IDbResolver
    {
        ISqlDbConnectionManager GetDbConnectionManager();
    }
}
