using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PrestadorService.Data.Repositories;
using PrestadorService.Model;

namespace PrestadorService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IPrestadorRepository<Prestador> _prestadorRepository;
        private readonly IEnderecoRepository<Endereco> _enderecoRepository;
        public EnderecoController(IPrestadorRepository<Prestador> prestadorRepository, IEnderecoRepository<Endereco> enderecoRepository)
        {
            _prestadorRepository = prestadorRepository;
            _enderecoRepository = enderecoRepository;
        }


        [HttpPost]
        [Route("/api/[controller]/{prestadorId}")]
        public Endereco Post(Endereco endereco, int prestadorId)
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

                var result = _enderecoRepository.Insert(endereco);

                prestador.Endereco = result;
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
        public Endereco Put(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                var result = _enderecoRepository.Update(endereco);
                return result;
            }
            else
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                throw new Exception(allErrors.ToString());
            }
        }

        [HttpGet]
        public Endereco Get(int id)
        {
            return _enderecoRepository.GetById(id);
        }

        [HttpDelete]
        public string Delete(int id)
        {
            var enderecoParaDeletar = _enderecoRepository.GetById(id);
            if (enderecoParaDeletar != null)
            {
                var prestador = _prestadorRepository.GetPrestadorWithEnderecoId(id);
                prestador.Endereco = null;
                _prestadorRepository.Update(prestador);

                _enderecoRepository.Delete(enderecoParaDeletar);
                return "{ response = 'Sucesso ao Excluir a o Endereço' }";
            }
            else
            {
                throw new Exception("Não foi encontrado um Endereço com os dados fornecidos.");
            }
        }
    }
}
