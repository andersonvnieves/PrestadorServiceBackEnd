using PrestadorService.Controllers;
using PrestadorService.Data.Repositories;
using PrestadorService.Model;
using PrestadorService.UnitTest.MockRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PrestadorService.UnitTest
{
    public class DadosBancariosTests
    {
        [Fact]
        public void DeveCadastrarPrestadorComDadosValidos()
        {
            //Arrange
            IDadosBancariosRepository<DadosBancarios> dadosBancariosRepository = new DadosBancariosMockRepository();
            IPrestadorRepository<Prestador> prestadorRepository = new PrestadorMockRepository();
            var prestadorController = new DadosBancariosController(dadosBancariosRepository, prestadorRepository);

            var prestadorId = 1;
            var dadosBancaraios = new DadosBancarios()
            {
                Banco = "FIAP",
                Agencia = "0001",
                ContaCorrente = "71029"
            };

            //Act
            var response = prestadorController.Post(dadosBancaraios, prestadorId);

            //Assert
            Assert.True(response.DadosBancariosId > 0);
            Assert.Equal(dadosBancaraios.DadosBancariosId, response.DadosBancariosId);
            Assert.Equal(dadosBancaraios.Banco, response.Banco);
            Assert.Equal(dadosBancaraios.Agencia, response.Agencia);
            Assert.Equal(dadosBancaraios.ContaCorrente, response.ContaCorrente);
        }


        [Fact]
        public void DeveAlterarDadosDoPrestadorComDadosValidos()
        {
            //Arrange
            IDadosBancariosRepository<DadosBancarios> dadosBancariosRepository = new DadosBancariosMockRepository();
            IPrestadorRepository<Prestador> prestadorRepository = new PrestadorMockRepository();
            var prestadorController = new DadosBancariosController(dadosBancariosRepository, prestadorRepository);

            var dadosBancaraios = new DadosBancarios()
            {
                DadosBancariosId = 1,
                Banco = "NOVO BANCO TESTE",
                Agencia = "0001",
                ContaCorrente = "337399"
            };

            //Act
            var response = prestadorController.Put(dadosBancaraios);

            //Assert
            Assert.True(response.DadosBancariosId > 0);
            Assert.Equal(dadosBancaraios.DadosBancariosId, response.DadosBancariosId);
            Assert.Equal(dadosBancaraios.Banco, response.Banco);
            Assert.Equal(dadosBancaraios.Agencia, response.Agencia);
            Assert.Equal(dadosBancaraios.ContaCorrente, response.ContaCorrente);
        }

        [Fact]
        public void DeveBuscarPrestadorPorId()
        {
            //Arrange
            IDadosBancariosRepository<DadosBancarios> dadosBancariosRepository = new DadosBancariosMockRepository();
            IPrestadorRepository<Prestador> prestadorRepository = new PrestadorMockRepository();
            var prestadorController = new DadosBancariosController(dadosBancariosRepository, prestadorRepository);


            //Act
            var response = prestadorController.Get(1);

            //Assert
            Assert.True(response.DadosBancariosId > 0);
            Assert.NotNull(response.Banco);
            Assert.NotNull(response.Agencia);
            Assert.NotNull(response.ContaCorrente);
        }
    }
}
