using CleanArchitecture.Data.Interfaces;

namespace CleanArchitecture.Data
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public abstract Task<T> Add(T entity);
        public abstract Task Delete(T entity);
        public abstract Task<IEnumerable<T>> Get();
        public abstract Task<T> Get(int id);
        public abstract Task<bool> Update(T entity);
    }
}
