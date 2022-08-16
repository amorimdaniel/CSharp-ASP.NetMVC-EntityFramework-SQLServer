using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeContatos.Models
{
    public class PecaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome da peça")]
        public string Nome { get; set; }

        [Display(Name = "Digite o preço")]
        [DisplayFormat(DataFormatString = "{0:f2}")]
        public double Preco { get; set; }

        [Required(ErrorMessage = "Digite a descrição da peça")]
        public string Descricao { get; set; }

    }
}
