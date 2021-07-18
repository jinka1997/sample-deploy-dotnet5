using System.Linq;

namespace Domain.Repositories
{
    public interface IQueryableRepository<TEntity>
    {
        TEntity GetById(long id);
        IQueryable<TEntity> GetAll();
    }
}
