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

        public IEnumerable<TEntity> AllInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return GetAllIncluding(includeProperties).ToList();
        }

        public IEnumerable<TEntity> FindByInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            IEnumerable<TEntity> results = query.Where(predicate).ToList();
            return results;
        }

        private IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> queryable = DbSet.AsNoTracking();

            return includeProperties.Aggregate
              (queryable, (current, includeProperty) => current.Include(includeProperty));
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
            DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            TEntity entity = FindById(id);
            DbSet.Remove(entity);
            DbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        public TEntity FindById(int id)
        {
            // Expression<Func<TEntity, bool>> lambda = Utilities.BuildLambdaForFindByKey<TEntity>(id);
            //return _dbSet.AsNoTracking().SingleOrDefault(lambda);
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