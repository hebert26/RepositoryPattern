using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RepositoryPattern.Classes;

namespace RepositoryImplementation
{
    public interface IRepository<T> where T : EntityBase
    {
        IEnumerable<T> AllInclude(params Expression<Func<T, object>>[] includeProperties);

        IEnumerable<T> FindByInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        T FindById(int id);

        IEnumerable<T> All();

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Delete(int entity);

        void Update(T entity);
    }
}