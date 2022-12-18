namespace CleanArchitecture.Data.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<bool> Update(T entity);
        Task Delete(T entity);
    }
}
