using Framework.Core.Domain;
using Framework.Data;

namespace Framework.Infrastrucutre.Repositories;

public class BaseRepository<TEntity> where TEntity : BaseEntity, IAggregateRoot
{
    private readonly BaseDbContext dbContext;

    public BaseRepository(BaseDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    protected void Create(TEntity entity)
    {
        dbContext.Set<TEntity>().Add(entity);
    }

    protected void Update(TEntity entity)
    {
        dbContext.Set<TEntity>().Update(entity);
    }

    protected void UpdateRange(IEnumerable<TEntity> entities)
    {
        dbContext.Set<TEntity>().UpdateRange(entities);
    }

    protected void Delete(TEntity entity)
    {
        dbContext.Set<TEntity>().Remove(entity);
    }
    
    protected void DeleteRange(IEnumerable<TEntity> entities)
    {
        dbContext.Set<TEntity>().RemoveRange(entities);
    }


}