using GerenciamentoDeContatos.Data;
using GerenciamentoDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeContatos.Repositorio
{
    public class PecaRepositorio : IPecaRepositorio
    {
        private readonly BancoContext _bancoContext;
        public PecaModel ListarPorId(int id)
        {
            return _bancoContext.Pecas.FirstOrDefault(x => x.Id == id);
        }
        public PecaRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public List<PecaModel> BuscarTodos()
        {
            return _bancoContext.Pecas.ToList();
        }
        public PecaModel Adicionar(PecaModel peca)
        {
            _bancoContext.Pecas.Add(peca);
            _bancoContext.SaveChanges();
            return peca;
        }

        public PecaModel Atualizar(PecaModel peca)
        {
            PecaModel pecaDB = ListarPorId(peca.Id);

            if(pecaDB == null){throw new Exception("Erro na atualização");}

            pecaDB.Nome = peca.Nome;
            pecaDB.Preco = peca.Preco;
            pecaDB.Descricao = peca.Descricao;

            _bancoContext.Update(pecaDB);
            _bancoContext.SaveChanges();
            return pecaDB;
        }

        public bool Apagar(int id)
        {
            PecaModel pecaDB = ListarPorId(id);
            if (pecaDB == null) { throw new Exception("Erro na deleção"); }

            _bancoContext.Pecas.Remove(pecaDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
