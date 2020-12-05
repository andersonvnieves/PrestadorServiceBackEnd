using PrestadorService.Data.Repositories;
using PrestadorService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestadorService.UnitTest.MockRepositories
{
    public class PrestadorMockRepository: IPrestadorRepository<Prestador>
    {
        public ICollection<Prestador> _prestador { get; set; }
        private int prestadorIdCount = 1;

        public PrestadorMockRepository()
        {
            _prestador = new List<Prestador>();
            _prestador.Add(new Prestador()
            {
                PrestadorId = 1,
                NomeCompleto = "Prestador Teste 0",
                DataNascimento = DateTime.Parse("1958-04-12"),
                RG = "448889995",
                CPF = "55566622235",
                CNH = "555888994",
                ValidadeCNH = DateTime.Parse("2025-07-02"),
                Email = "prestadorteste0@fiap.com.br",
                Celular = "11988884447",
            });
        }


        public void Delete(Prestador entity)
        {
            _prestador.Remove(entity);
        }

        public Prestador GetById(int id)
        {
            return _prestador.Where(c => c.PrestadorId == id).FirstOrDefault();
        }

        public Prestador Insert(Prestador entity)
        {
            prestadorIdCount++;
            entity.PrestadorId = prestadorIdCount;
            _prestador.Add(entity);
            return entity;
        }

        public ICollection<Prestador> List()
        {
            return _prestador.ToList();
        }

        public Prestador Update(Prestador entity)
        {
            _prestador.Remove(_prestador.Where(c => c.PrestadorId == entity.PrestadorId).FirstOrDefault());
            _prestador.Add(entity);
            return entity;
        }

        public Prestador GetPrestadorWithDadosBancariosId(int id)
        {
            return _prestador.Where(c => c.DadosBancarios.DadosBancariosId == id).FirstOrDefault();
        }

        public Prestador GetPrestadorWithEnderecoId(int id)
        {
            return _prestador.Where(c => c.Endereco.EnderecoId == id).FirstOrDefault();
        }
    }
}
