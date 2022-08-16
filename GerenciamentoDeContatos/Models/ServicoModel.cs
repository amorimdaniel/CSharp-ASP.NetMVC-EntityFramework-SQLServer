using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeContatos.Models
{
    public class ServicoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do serviço")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o preço do serviço")]
        public double Preco { get; set; }

        [Required(ErrorMessage = "Digite a descrição do serviço")]
        public string Descricao { get; set; }


    }
}
