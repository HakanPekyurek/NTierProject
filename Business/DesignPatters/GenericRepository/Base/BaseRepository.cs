using Business.DesignPatters.GenericRepository.Interface;
using Business.DesignPatters.SingletonPattern;
using DAL.Context;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Business.DesignPatters.GenericRepository.Base
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        MyContext _context;
        public BaseRepository()
        {
            _context = DbTool.DbInstance;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(List<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Any(exp);
        }

        public void Delete(T entity)
        {
            entity.DataStatus = Entities.Enums.DataStatus.Deleted;
            entity.DeletedDate = DateTime.Now;
            _context.SaveChanges();
        }

        public void DeleteRange(List<T> entities)
        {
            foreach (T item in entities)
            {
                Delete(item);
            }
        }

        public void Destroy(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void DestroyRange(List<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            _context.SaveChanges();
        }

        public T Find(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().FirstOrDefault(exp);
        }

        public List<T> GetActive()
        {
            return Where(h => h.DataStatus != Entities.Enums.DataStatus.Deleted);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public List<T> GetDeleteds()
        {
            return Where(h => h.DataStatus == Entities.Enums.DataStatus.Deleted);
        }

        public List<T> GetModifieds()
        {
            return Where(h => h.DataStatus == Entities.Enums.DataStatus.Updated);
        }

        public object Select(Expression<Func<T, object>> exp)
        {
            return _context.Set<T>().Select(exp);
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            return _context.Set<T>().Where(h => h.DataStatus != Entities.Enums.DataStatus.Deleted).Select(exp);
        }

        public void Update(T entity)
        {
            entity.DataStatus = Entities.Enums.DataStatus.Updated;
            entity.UpdatedDate = DateTime.Now;

            T unUpdatedItem = Find(entity.Id);
            _context.Entry(unUpdatedItem).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }

        public void UpdateRange(List<T> entities)
        {
            foreach (T item in entities)
            {
                Update(item);
            }
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(exp).ToList();
        }
    }
}
