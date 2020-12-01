using Microsoft.EntityFrameworkCore;
using PrestadorService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrestadorService.Data.Repositories
{
    public class PrestadorRepository: GenericRepository<Prestador>, IPrestadorRepository<Prestador>
    {
        private readonly PrestadorDbContext _prestadorDbContext;
        private readonly DbSet<Prestador> _dbSet;

        public PrestadorRepository(PrestadorDbContext prestadorDbContext) : base(prestadorDbContext)
        {
            _prestadorDbContext = prestadorDbContext;
            _dbSet = _prestadorDbContext.Set<Prestador>();
        }
        public Prestador GetById(int id)
        {
            return _dbSet.Include(i => i.Endereco).Include(i => i.DadosBancarios).Where(c => c.PrestadorId == id).FirstOrDefault();
        }

        
    }
}
