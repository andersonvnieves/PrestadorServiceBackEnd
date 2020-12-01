using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrestadorService.Model
{
    public class Prestador
    {
        public int PrestadorId { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string NomeCompleto { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string RG { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string CNH { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime ValidadeCNH { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Celular { get; set; }
        public Endereco Endereco { get; set; }
        public DadosBancarios DadosBancarios { get; set; }
    }
}
