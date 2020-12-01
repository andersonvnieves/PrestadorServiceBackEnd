using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrestadorService.Model
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Numero { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string CEP { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Cidade { get; set; }
        public string Complemento { get; set; }
    }
}
