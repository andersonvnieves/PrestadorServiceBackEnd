using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PrestadorService.Data.Repositories;
using PrestadorService.Model;

namespace PrestadorService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DadosBancariosController : ControllerBase
    {
        private readonly IDadosBancariosRepository<DadosBancarios> _dadosBancariosRepository;
        private readonly IPrestadorRepository<Prestador> _prestadorRepository;
        public DadosBancariosController(IDadosBancariosRepository<DadosBancarios> dadosBancariosRepository, IPrestadorRepository<Prestador> prestadorRepository)
        {
            _dadosBancariosRepository = dadosBancariosRepository;
            _prestadorRepository = prestadorRepository;
        }


        [HttpPost]
        [Route("/api/[controller]/{prestadorId}")]
        public DadosBancarios Post(DadosBancarios dadosBancarios, int prestadorId)
        {
            if (ModelState.IsValid)
            {
                //Validar PrestadorId
                var prestador = _prestadorRepository.GetById(prestadorId);
                if (prestador == null)
                {
                    ModelState.AddModelError("PrestadorId", "Nenhum Prestador encontrado com o Id informado.");
                    IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                    throw new Exception(allErrors.ToString());
                }

                var result = _dadosBancariosRepository.Insert(dadosBancarios);

                prestador.DadosBancarios = result;
                _prestadorRepository.Update(prestador);


                return result;
            }
            else
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                throw new Exception(allErrors.ToString());
            }
        }

        [HttpPut]
        public DadosBancarios Put(DadosBancarios dadosBancarios)
        {
            if (ModelState.IsValid)
            {
                var result = _dadosBancariosRepository.Update(dadosBancarios);
                return result;
            }
            else
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                throw new Exception(allErrors.ToString());
            }
        }

        [HttpGet]
        public DadosBancarios Get(int id)
        {
            return _dadosBancariosRepository.GetById(id);
        }

        [HttpDelete]
        public string Delete(int id)
        {
            var dadosBancariosParaDeletar = _dadosBancariosRepository.GetById(id);
            if (dadosBancariosParaDeletar != null)
            {
                var prestador = _prestadorRepository.GetPrestadorWithDadosBancariosId(id);
                prestador.DadosBancarios = null;
                _prestadorRepository.Update(prestador);

                _dadosBancariosRepository.Delete(dadosBancariosParaDeletar);
                return "{ response = 'Sucesso ao Excluir Dados Bancários' }";
            }
            else
            {
                throw new Exception("Não foram encontrados Dados Bancários com os dados fornecidos.");
            }
        }
    }
}
