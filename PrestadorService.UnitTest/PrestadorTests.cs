using Microsoft.AspNetCore.Mvc;
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
    public class PrestadorTests
    {

        [Fact]
        public void DeveCadastrarPrestadorComDadosValidos()
        {
            //Arrange
            IPrestadorRepository<Prestador> prestadorRepository = new PrestadorMockRepository();
            var prestadorController = new PrestadorController(prestadorRepository);

            var prestador = new Prestador()
            {
                NomeCompleto = "Prestador Teste 1",
                DataNascimento = DateTime.Parse("1958-04-12"),
                RG = "448889996",
                CPF = "55566622233",
                CNH = "555888995",
                ValidadeCNH = DateTime.Parse("2025-07-02"),
                Email = "prestadorteste@fiap.com.br",
                Celular = "11988884444",
            };

            //Act
            var response = prestadorController.Post(prestador);

            //Assert
            Assert.True(response.PrestadorId > 0);
            Assert.Equal(prestador.NomeCompleto, response.NomeCompleto);
            Assert.Equal(prestador.DataNascimento, response.DataNascimento);
            Assert.Equal(prestador.RG, response.RG);
            Assert.Equal(prestador.CPF, response.CPF);
            Assert.Equal(prestador.CNH, response.CNH);
            Assert.Equal(prestador.ValidadeCNH, response.ValidadeCNH);
            Assert.Equal(prestador.Email, response.Email);
            Assert.Equal(prestador.Celular, response.Celular);
        }


        [Fact]
        public void DeveAlterarDadosDoPrestadorComDadosValidos()
        {
            //Arrange
            IPrestadorRepository<Prestador> prestadorRepository = new PrestadorMockRepository();
            var prestadorController = new PrestadorController(prestadorRepository);

            var prestadorUpdate = new Prestador()
            {
                PrestadorId = 1,
                NomeCompleto = "Prestador Teste 0 Atualizado",
                DataNascimento = DateTime.Parse("1958-04-12"),
                RG = "448889995",
                CPF = "55566622235",
                CNH = "555888994",
                ValidadeCNH = DateTime.Parse("2025-07-02"),
                Email = "prestadorteste0@fiap.com.br",
                Celular = "11988884447",
            };

            //Act
            var response = prestadorController.Put(prestadorUpdate);

            //Assert
            Assert.True(response.PrestadorId > 0);
            Assert.Equal(prestadorUpdate.NomeCompleto, response.NomeCompleto);
            Assert.Equal(prestadorUpdate.DataNascimento, response.DataNascimento);
            Assert.Equal(prestadorUpdate.RG, response.RG);
            Assert.Equal(prestadorUpdate.CPF, response.CPF);
            Assert.Equal(prestadorUpdate.CNH, response.CNH);
            Assert.Equal(prestadorUpdate.ValidadeCNH, response.ValidadeCNH);
            Assert.Equal(prestadorUpdate.Email, response.Email);
            Assert.Equal(prestadorUpdate.Celular, response.Celular);
        }

        [Fact]
        public void DeveBuscarPrestadorPorId()
        {
            //Arrange
            IPrestadorRepository<Prestador> prestadorRepository = new PrestadorMockRepository();
            var prestadorController = new PrestadorController(prestadorRepository);            

            //Act
            var response = prestadorController.Get(1);

            //Assert
            Assert.True(response.PrestadorId > 0);
            Assert.NotNull(response.NomeCompleto);
            Assert.NotNull(response.RG);
            Assert.NotNull(response.CPF);
            Assert.NotNull(response.CNH);
            Assert.NotNull(response.Email);
            Assert.NotNull(response.Celular);
        }

        [Fact]
        public void DeveListarTodosOsPrestadores()
        {
            //Arrange
            IPrestadorRepository<Prestador> prestadorRepository = new PrestadorMockRepository();
            var prestadorController = new PrestadorController(prestadorRepository);

            //Act
            var response = prestadorController.Get();

            //Assert
            Assert.NotEmpty(response);
        }
    }
}
