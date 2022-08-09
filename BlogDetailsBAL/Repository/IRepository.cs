using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BlogDetailsBAL.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAllById(Expression<Func<T, bool>> predicate);

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Delete(T entity);

        void Edit(T entity);

        void Save();

        void AddRange(IEnumerable<T> entities);

        void RemoveRange(IEnumerable<T> entities);
        int Count(IEnumerable<T> entities);

        IEnumerable<T> GetRange(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
        IList<Expression<Func<T, object>>> includes, int? page, int? pageSize);

    }
}
