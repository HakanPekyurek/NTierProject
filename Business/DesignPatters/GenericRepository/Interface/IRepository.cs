using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Business.DesignPatters.GenericRepository.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        List<T> GetAll();
        List<T> GetActive();
        List<T> GetModifieds();
        List<T> GetDeleteds();

        void Add(T entity);
        void AddRange(List<T> entities);
        void Update(T entity);
        void UpdateRange(List<T> entities);
        void Delete(T entity);
        void DeleteRange(List<T> entities);
        void Destroy(T entity);
        void DestroyRange(List<T> entities);

        //_db.Products.Where(h => h.Name.Contains("a").ToList());
        List<T> Where(Expression<Func<T, bool>> exp);
        bool Any(Expression<Func<T, bool>> exp);
        T FirstOrDefault(Expression<Func<T, bool>> exp);
        object Select(Expression<Func<T, object>> exp); // _db.Products.Select(h=> new{})

        IQueryable<X> Select<X>(Expression<Func<T, X>> exp); //_db.Products.Select(h=> new CategotyDTO{})

        T Find(int id);
    }
}
