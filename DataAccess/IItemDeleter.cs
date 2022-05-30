namespace ADOStuff.DataAccess
{
    public interface IItemDeleter
    {
        bool Delete(string table, (string keyName, int key) key);
    }
}
