using Candidate.Entity;
using Candidate.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Candidate.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly CandidateDbContext _context;
        protected readonly DbSet<T> dbset;
        public Repository(CandidateDbContext context)
        {
            _context = context;
            this.dbset = _context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            this.dbset.Add(entity);
        }

        public virtual void Update(T entity)
        {
            var entry = _context.Entry(entity);
            this.dbset.Attach(entity);
            entry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            var entry = _context.Entry(entity);
            entry.State = EntityState.Deleted;
        }

        /// <summary>
        /// To get the entities by provided condition asynchronously.
        /// </summary>
        /// <param name="predicate">The conditions to filter with.</param>
        /// <param name="includes">The 0 or more navigation properties to include for EF eager loading.</param>
        /// <returns>The list of entities</returns>
        public async Task<List<T>> GetByAsync(Expression<Func<T, bool>> predicate)
        {
            return await this.dbset.Where(predicate).ToListAsync().ConfigureAwait(false);
        }

    }
}