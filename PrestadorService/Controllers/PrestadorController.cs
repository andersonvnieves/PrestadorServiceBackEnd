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
    public class PrestadorController : ControllerBase
    {
        private readonly IPrestadorRepository<Prestador> _prestadorRepository;
        public PrestadorController(IPrestadorRepository<Prestador> prestadorRepository)
        {
            _prestadorRepository = prestadorRepository;
        }

        [HttpPost]
        public Prestador Post(Prestador prestador)
        {
            if (ModelState.IsValid)
            {
                var result = _prestadorRepository.Insert(prestador);
                return result;
            }
            else
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                throw new Exception(allErrors.ToString());
            }
        }

        [HttpPut]
        public Prestador Put(Prestador prestador)
        {
            if (ModelState.IsValid)
            {
                var result = _prestadorRepository.Update(prestador);
                return result;
            }
            else
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                throw new Exception(allErrors.ToString());
            }
        }

        [HttpGet]
        public Prestador Get(int id)
        {
            return _prestadorRepository.GetById(id);
        }

        [HttpGet]
        [Route("List")]
        public ICollection<Prestador> Get()
        {
            return _prestadorRepository.List();
        }

        [HttpDelete]
        public string Delete(int id)
        {
            var prestadorParaDeletar = _prestadorRepository.GetById(id);
            if (prestadorParaDeletar != null)
            {
                //if(prestadorParaDeletar.Endereco != null)
                //    _


                _prestadorRepository.Delete(prestadorParaDeletar);
                return "Sucesso ao Excluir o Prestador";
            }
            else
            {
                throw new Exception("Não foi encontrado um Prestador com os dados fornecidos.");
            }
        }

    }
}
