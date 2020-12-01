using Microsoft.EntityFrameworkCore;
using PrestadorService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrestadorService.Data.Repositories
{
    public class EnderecoRepository: GenericRepository<Endereco>, IEnderecoRepository<Endereco>
    {
        private readonly PrestadorDbContext _prestadorDbContext;
        private readonly DbSet<Endereco> _dbSet;

        public EnderecoRepository(PrestadorDbContext prestadorDbContext): base(prestadorDbContext)
        {
            _prestadorDbContext = prestadorDbContext;
            _dbSet = _prestadorDbContext.Set<Endereco>();
        }

        public Endereco GetById(int id)
        {
            return _dbSet.Where(c => c.EnderecoId == id).FirstOrDefault();
        }

    }
}
