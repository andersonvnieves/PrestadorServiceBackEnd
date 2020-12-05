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
    public class DadosBancariosTests
    {
        [Fact]
        public void DeveCadastrarDadosBancariosComDadosValidos()
        {
            //Arrange
            IDadosBancariosRepository<DadosBancarios> dadosBancariosRepository = new DadosBancariosMockRepository();
            IPrestadorRepository<Prestador> prestadorRepository = new PrestadorMockRepository();
            var dadosBancariosController = new DadosBancariosController(dadosBancariosRepository, prestadorRepository);

            var prestadorId = 1;
            var dadosBancaraios = new DadosBancarios()
            {
                Banco = "FIAP",
                Agencia = "0001",
                ContaCorrente = "71029"
            };

            //Act
            var response = dadosBancariosController.Post(dadosBancaraios, prestadorId);

            //Assert
            Assert.True(response.DadosBancariosId > 0);
            Assert.Equal(dadosBancaraios.DadosBancariosId, response.DadosBancariosId);
            Assert.Equal(dadosBancaraios.Banco, response.Banco);
            Assert.Equal(dadosBancaraios.Agencia, response.Agencia);
            Assert.Equal(dadosBancaraios.ContaCorrente, response.ContaCorrente);
        }


        [Fact]
        public void DeveAlterarDadosDoDadosBancariosComDadosValidos()
        {
            //Arrange
            IDadosBancariosRepository<DadosBancarios> dadosBancariosRepository = new DadosBancariosMockRepository();
            IPrestadorRepository<Prestador> prestadorRepository = new PrestadorMockRepository();
            var dadosBancariosController = new DadosBancariosController(dadosBancariosRepository, prestadorRepository);

            var dadosBancaraios = new DadosBancarios()
            {
                DadosBancariosId = 1,
                Banco = "NOVO BANCO TESTE",
                Agencia = "0001",
                ContaCorrente = "337399"
            };

            //Act
            var response = dadosBancariosController.Put(dadosBancaraios);

            //Assert
            Assert.True(response.DadosBancariosId > 0);
            Assert.Equal(dadosBancaraios.DadosBancariosId, response.DadosBancariosId);
            Assert.Equal(dadosBancaraios.Banco, response.Banco);
            Assert.Equal(dadosBancaraios.Agencia, response.Agencia);
            Assert.Equal(dadosBancaraios.ContaCorrente, response.ContaCorrente);
        }

        [Fact]
        public void DeveBuscarDadosBancariosPorId()
        {
            //Arrange
            IDadosBancariosRepository<DadosBancarios> dadosBancariosRepository = new DadosBancariosMockRepository();
            IPrestadorRepository<Prestador> prestadorRepository = new PrestadorMockRepository();
            var dadosBancariosController = new DadosBancariosController(dadosBancariosRepository, prestadorRepository);


            //Act
            var response = dadosBancariosController.Get(1);

            //Assert
            Assert.True(response.DadosBancariosId > 0);
            Assert.NotNull(response.Banco);
            Assert.NotNull(response.Agencia);
            Assert.NotNull(response.ContaCorrente);
        }

        [Fact]
        public void DeveExcluirDadosBancarios()
        {
            //Arrange
            IDadosBancariosRepository<DadosBancarios> dadosBancariosRepository = new DadosBancariosMockRepository();
            IPrestadorRepository<Prestador> prestadorRepository = new PrestadorMockRepository();
            var dadosBancariosController = new DadosBancariosController(dadosBancariosRepository, prestadorRepository);

            //Act
            var response = dadosBancariosController.Delete(1);

            //Assert
            Assert.Equal("Sucesso ao Excluir Dados Bancários", response);
            Assert.True(!dadosBancariosRepository.List().Any());

        }
    }
}
