using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrestadorService.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private PrestadorDbContext _context;
        protected DbSet<T> _dbSet;

        public GenericRepository(PrestadorDbContext context)
        {
            this._context = context;
            this._dbSet = context.Set<T>();
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
            Save();
        }

        public virtual T Insert(T entity)
        {
            var result = _dbSet.Add(entity);
            Save();
            return result.Entity;
        }

        public virtual ICollection<T> List()
        {
            return _dbSet.ToList();
        }

        public virtual T Update(T entity)
        {
            var result = _dbSet.Update(entity);
            Save();
            return result.Entity;
        }

        private void Save()
        {
            _context.SaveChanges();
        }
    }
}
