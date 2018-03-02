using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RepositoryImplementation
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        IEnumerable<TEntity> AllInclude(params Expression<Func<TEntity, object>>[] includeProperties);

        IEnumerable<TEntity> FindByInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity FindById(int id);

        IEnumerable<TEntity> All();

        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);

        void Delete(int entity);

        void Update(TEntity entity);
    }
}