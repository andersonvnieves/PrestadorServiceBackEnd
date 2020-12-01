using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrestadorService.Data.Repositories
{
    public interface IPrestadorRepository<T> : IGenericRepository<T>
    {
        T GetById(int id);
    }
}
