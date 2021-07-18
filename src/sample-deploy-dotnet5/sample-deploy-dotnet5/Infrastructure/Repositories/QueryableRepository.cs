using Domain.Models.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class QueryableRepository<TEntity> : IQueryableRepository<TEntity> where TEntity : Entity
    {
        protected readonly DbSet<TEntity> _table;

        public QueryableRepository(SampleContext context)
        {
            _table = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll() => _table.AsNoTracking();

        public TEntity GetById(long id) => _table.Find(id);
    }

}
