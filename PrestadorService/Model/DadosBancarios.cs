using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrestadorService.Model
{
    public class DadosBancarios
    {
        public int DadosBancariosId { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Banco { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Agencia { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string ContaCorrente { get; set; }
    }
}
