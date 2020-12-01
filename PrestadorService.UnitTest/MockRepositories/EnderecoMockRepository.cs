
using PrestadorService.Data.Repositories;
using PrestadorService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestadorService.UnitTest.MockRepositories
{
   public class EnderecoMockRepository: IEnderecoRepository<Endereco>
    {
        public ICollection<Endereco> _endereco { get; set; }
        private int enderecoIdCount = 1;

        public EnderecoMockRepository()
        {
            _endereco = new List<Endereco>();

            _endereco.Add(new Endereco()
            {
                EnderecoId = 1,
                Logradouro = "Avenida São João",
                Numero = "100",
                Bairro = "Santa Efigenia",
                CEP = "00000-555",
                Estado = "SP",
                Cidade = "São Paulo",
                Complemento = "Endereço de Teste 1"
            });

        }
        public void Delete(Endereco entity)
        {
            _endereco.Remove(entity);
        }

        public Endereco GetById(int id)
        {
            return _endereco.Where(c => c.EnderecoId == id).FirstOrDefault();
        }

        public Endereco Insert(Endereco entity)
        {
            enderecoIdCount++;
            entity.EnderecoId = enderecoIdCount;
            _endereco.Add(entity);
            return entity;
        }

        public ICollection<Endereco> List()
        {
            return _endereco.ToList();
        }

        public Endereco Update(Endereco entity)
        {
            _endereco.Remove(_endereco.Where(c => c.EnderecoId == entity.EnderecoId).FirstOrDefault());
            _endereco.Add(entity);
            return entity;
        }
    }
}
