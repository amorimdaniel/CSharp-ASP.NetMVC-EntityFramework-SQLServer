using GerenciamentoDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeContatos.Repositorio
{
    public interface IPecaRepositorio
    {
        PecaModel ListarPorId(int id);
        List<PecaModel> BuscarTodos();
        PecaModel Adicionar(PecaModel peca);
        PecaModel Atualizar(PecaModel peca);
        bool Apagar(int id);
    }
}
