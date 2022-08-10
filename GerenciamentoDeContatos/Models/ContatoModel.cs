using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do contato")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "E-mail informado inválido")]
        [Required(ErrorMessage = "Digite o e-mail do contato")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Número celular inválido")]
        [Required(ErrorMessage = "Digite o celular do contato")]
        public string Celular { get; set; }


    }
}
