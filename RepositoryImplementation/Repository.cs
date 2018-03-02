using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using RepositoryPattern.Classes;

namespace RepositoryImplementation
{
    public class Repository<T> : IRepository<T> where T : EntityBase

    {
        internal DbContext DbContext;
        internal DbSet<T> DbSet;

        public Repository(DbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<T>();
        }

        public IEnumerable<T> AllInclude(params Expression<Func<T, object>>[] includeProperties)
        {
            return GetAllIncluding(includeProperties).ToList();
        }

        public IEnumerable<T> FindByInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            IEnumerable<T> results = query.Where(predicate).ToList();
            return results;
        }

        private IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = DbSet.AsNoTracking();

            return includeProperties.Aggregate
              (queryable, (current, includeProperty) => current.Include(includeProperty));
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
            DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = FindById(id);
            DbSet.Remove(entity);
            DbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        public T FindById(int id)
        {
            // Expression<Func<TEntity, bool>> lambda = Utilities.BuildLambdaForFindByKey<TEntity>(id);
            //return _dbSet.AsNoTracking().SingleOrDefault(lambda);
            return DbSet.AsNoTracking().SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> All()
        {
            return DbSet.AsNoTracking().AsEnumerable();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> result = DbSet.AsNoTracking()
                .Where(predicate).AsEnumerable();
            return result;
        }
    }
}