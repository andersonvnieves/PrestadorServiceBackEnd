
using Microsoft.EntityFrameworkCore;
using PrestadorService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrestadorService.Data
{
    public class PrestadorDbContext: DbContext
    {
        public PrestadorDbContext(DbContextOptions<PrestadorDbContext> options) : base(options)
        {
        }

        public DbSet<DadosBancarios> DadosBancarios { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Prestador> Prestador { get; set; }
    }
}
