using GerenciamentoDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeContatos.Repositorio
{
    public interface IServicoRepositorio
    {
        ServicoModel ListarPorId(int id);
        List<ServicoModel> BuscarTodos();
        ServicoModel Adicionar(ServicoModel servico);
        ServicoModel Atualizar(ServicoModel peca);
        bool Apagar(int id);
    }
}
