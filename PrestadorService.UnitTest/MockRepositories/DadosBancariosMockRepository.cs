using PrestadorService.Data.Repositories;
using PrestadorService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestadorService.UnitTest.MockRepositories
{
    public class DadosBancariosMockRepository : IDadosBancariosRepository<DadosBancarios>
    {
        public ICollection<DadosBancarios> _dadosBancarios { get; set; }
        private int dadosBancariosIdCount = 1;

        public DadosBancariosMockRepository()
        {
            _dadosBancarios = new List<DadosBancarios>();

            _dadosBancarios.Add(new DadosBancarios() {
                DadosBancariosId = 1,
                Banco = "FIAP",
                Agencia = "0001",
                ContaCorrente = "337399"
            });
        }

        public void Delete(DadosBancarios entity)
        {
            _dadosBancarios.Remove(entity);
        }

        public DadosBancarios GetById(int id)
        {
            return _dadosBancarios.Where(c => c.DadosBancariosId == id).FirstOrDefault();
        }

        public DadosBancarios Insert(DadosBancarios entity)
        {
            dadosBancariosIdCount++;
            entity.DadosBancariosId = dadosBancariosIdCount;
            _dadosBancarios.Add(entity);
            return entity;
        }

        public ICollection<DadosBancarios> List()
        {
            return _dadosBancarios.ToList();
        }

        public DadosBancarios Update(DadosBancarios entity)
        {
            _dadosBancarios.Remove(_dadosBancarios.Where(c => c.DadosBancariosId == entity.DadosBancariosId).FirstOrDefault());
            _dadosBancarios.Add(entity);
            return entity;
        }
    }
}
