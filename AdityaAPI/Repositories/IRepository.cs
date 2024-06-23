namespace AdityaAPI.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(string tableName, string storedProcedureName);
    }
}
