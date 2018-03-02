using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace RepositoryImplementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity

    {
        internal DbContext DbContext;
        internal DbSet<TEntity> DbSet;

        public Repository(DbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity FindById(int id)
        {
            return DbSet.AsNoTracking().SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<TEntity> All()
        {
            return DbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> result = DbSet.AsNoTracking()
                .Where(predicate).ToList();

            return result;
        }
    }
}