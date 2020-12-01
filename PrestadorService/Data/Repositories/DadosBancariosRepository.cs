using Microsoft.EntityFrameworkCore;
using PrestadorService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrestadorService.Data.Repositories
{
    public class DadosBancariosRepository: GenericRepository<DadosBancarios>, IDadosBancariosRepository<DadosBancarios>
    {
        private readonly PrestadorDbContext _prestadorDbContext;
        private readonly DbSet<DadosBancarios> _dbSet;

        public DadosBancariosRepository(PrestadorDbContext prestadorDbContext): base(prestadorDbContext)
        {
            _prestadorDbContext = prestadorDbContext;
            _dbSet = _prestadorDbContext.Set<DadosBancarios>();
        }

        public DadosBancarios GetById(int id)
        {
            return _dbSet.Where(c => c.DadosBancariosId == id).FirstOrDefault();
        }

    }
}
