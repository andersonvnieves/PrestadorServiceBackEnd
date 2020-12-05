using PrestadorService.Controllers;
using PrestadorService.Data.Repositories;
using PrestadorService.Model;
using PrestadorService.UnitTest.MockRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace PrestadorService.UnitTest
{
    public class EnderecoTests
    {
        [Fact]
        public void DeveCadastrarEnderecoComDadosValidos()
        {
            //Arrange
            IEnderecoRepository<Endereco> enderecoRepository = new EnderecoMockRepository();
            IPrestadorRepository<Prestador> prestadorRepository = new PrestadorMockRepository();
            var enderecoController = new EnderecoController(prestadorRepository, enderecoRepository);

            var prestadorId = 1;
            var endereco = new Endereco()
            {
                Logradouro = "Avenida Paulistsa",
                Numero = "1500",
                Bairro = "Cerqueira Cesar",
                CEP = "00000-444",
                Estado = "SP",
                Cidade = "São Paulo",
                Complemento = "Endereço de Teste 2"
            };

            //Act
            var response = enderecoController.Post(endereco, prestadorId);

            //Assert
            Assert.True(response.EnderecoId > 0);
            Assert.Equal(endereco.EnderecoId, response.EnderecoId);
            Assert.Equal(endereco.Logradouro, response.Logradouro);
            Assert.Equal(endereco.Numero, response.Numero);
            Assert.Equal(endereco.Bairro, response.Bairro);
            Assert.Equal(endereco.CEP, response.CEP);
            Assert.Equal(endereco.Estado, response.Estado);
            Assert.Equal(endereco.Cidade, response.Cidade);
            Assert.Equal(endereco.Complemento, response.Complemento);
        }


        [Fact]
        public void DeveAlterarDadosDoEnderecoComDadosValidos()
        {
            //Arrange
            IEnderecoRepository<Endereco> enderecoRepository = new EnderecoMockRepository();
            IPrestadorRepository<Prestador> prestadorRepository = new PrestadorMockRepository();
            var enderecoController = new EnderecoController(prestadorRepository, enderecoRepository);

            var endereco = new Endereco()
            {
                EnderecoId = 2,
                Logradouro = "Avenida Paulistsa Atualziado",
                Numero = "1500",
                Bairro = "Cerqueira Cesar",
                CEP = "00000-444",
                Estado = "SP",
                Cidade = "São Paulo",
                Complemento = "Endereço de Teste 2"
            };

            //Act
            var response = enderecoController.Put(endereco);

            //Assert
            Assert.True(response.EnderecoId > 0);
            Assert.Equal(endereco.EnderecoId, response.EnderecoId);
            Assert.Equal(endereco.Logradouro, response.Logradouro);
            Assert.Equal(endereco.Numero, response.Numero);
            Assert.Equal(endereco.Bairro, response.Bairro);
            Assert.Equal(endereco.CEP, response.CEP);
            Assert.Equal(endereco.Estado, response.Estado);
            Assert.Equal(endereco.Cidade, response.Cidade);
            Assert.Equal(endereco.Complemento, response.Complemento);
        }

        [Fact]
        public void DeveBuscarEnderecoPorId()
        {
            //Arrange
            IEnderecoRepository<Endereco> enderecoRepository = new EnderecoMockRepository();
            IPrestadorRepository<Prestador> prestadorRepository = new PrestadorMockRepository();
            var enderecoController = new EnderecoController(prestadorRepository, enderecoRepository);


            //Act
            var response = enderecoController.Get(1);

            //Assert
            Assert.True(response.EnderecoId > 0);
            Assert.NotNull(response.EnderecoId);
            Assert.NotNull(response.Logradouro);
            Assert.NotNull(response.Numero);
            Assert.NotNull(response.Bairro);
            Assert.NotNull(response.CEP);
            Assert.NotNull(response.Estado);
            Assert.NotNull(response.Cidade);
            Assert.NotNull(response.Complemento);
        }

        [Fact]
        public void DeveExcluirEndereco()
        {
            //Arrange
            IEnderecoRepository<Endereco> enderecoRepository = new EnderecoMockRepository();
            IPrestadorRepository<Prestador> prestadorRepository = new PrestadorMockRepository();
            var enderecoController = new EnderecoController(prestadorRepository, enderecoRepository);

            //Act
            var response = enderecoController.Delete(1);

            //Assert
            Assert.Equal("Sucesso ao Excluir a o Endereço", response);
            Assert.True(!enderecoRepository.List().Any());

        }
    }
}
