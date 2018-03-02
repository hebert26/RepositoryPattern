using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RepositoryImplementation
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        TEntity FindById(int id);

        IEnumerable<TEntity> All();

        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);

        void Delete(TEntity entity);

        void Edit(TEntity entity);
    }
}