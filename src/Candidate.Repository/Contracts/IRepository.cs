using Candidate.Entity;
using System.Linq.Expressions;

namespace Candidate.Repository.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<List<T>> GetByAsync(Expression<Func<T, bool>> predicate);
        Task<int> SaveChangesAsync();
        Task<List<T>> GetAllAsync();
        void Remove(T entity);
    }
}
