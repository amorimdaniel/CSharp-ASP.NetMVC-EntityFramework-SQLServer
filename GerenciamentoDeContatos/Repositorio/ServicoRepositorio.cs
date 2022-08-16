using GerenciamentoDeContatos.Data;
using GerenciamentoDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeContatos.Repositorio
{
    public class ServicoRepositorio : IServicoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ServicoModel ListarPorId(int id)
        {
            return _bancoContext.Servicos.FirstOrDefault(x => x.Id == id);
        }
        public ServicoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public List<ServicoModel> BuscarTodos()
        {
            return _bancoContext.Servicos.ToList();
        }
        public ServicoModel Adicionar(ServicoModel servico)
        {
            _bancoContext.Servicos.Add(servico);
            _bancoContext.SaveChanges();
            return servico;
        }

        public ServicoModel Atualizar(ServicoModel servico)
        {
            ServicoModel servicoDB = ListarPorId(servico.Id);

            if(servicoDB == null){throw new Exception("Erro na atualização");}

            servicoDB.Nome = servico.Nome;
            servicoDB.Preco =servico.Preco;
            servicoDB.Descricao = servico.Descricao;

            _bancoContext.Update(servicoDB);
            _bancoContext.SaveChanges();
            return servicoDB;
        }

        public bool Apagar(int id)
        {
            ServicoModel servicoDB = ListarPorId(id);
            if (servicoDB == null) { throw new Exception("Erro na deleção"); }

            _bancoContext.Remove(servicoDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
