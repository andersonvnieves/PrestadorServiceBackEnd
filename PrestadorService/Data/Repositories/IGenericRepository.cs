using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrestadorService.Data.Repositories
{
    public interface IGenericRepository<T>
    {
        T Insert(T entity);
        T Update(T entity);
        void Delete(T entity);
        ICollection<T> List();
    }
}
