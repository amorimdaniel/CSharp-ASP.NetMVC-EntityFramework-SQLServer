using GerenciamentoDeContatos.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeContatos.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do contato")]
        public string Nome { get; set; }
        public string Login { get; set; }
        [EmailAddress(ErrorMessage = "E-mail informado inválido")]
        [Required(ErrorMessage = "Digite o e-mail do contato")]
        public string  Email { get; set; }
        [Required(ErrorMessage = "Informe perfil do usuário")]
        public PerfilEnum? Perfil { get; set; }
        [Required(ErrorMessage = "Digite a senha do usário")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    
        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }
    }
}
