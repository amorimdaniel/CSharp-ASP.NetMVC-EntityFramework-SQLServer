using GerenciamentoDeContatos.Filters;
using GerenciamentoDeContatos.Models;
using GerenciamentoDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeContatos.Controllers
{
    [PaginaParaUsuarioLogado]
    public class ServicoController : Controller
    {

        private readonly IServicoRepositorio _servicoRepositorio;
        public ServicoController(IServicoRepositorio servicoRepositorio)
        {
            _servicoRepositorio = servicoRepositorio;
        }
        public IActionResult Index()
        {
            List<ServicoModel> servicos = _servicoRepositorio.BuscarTodos();
            return View(servicos);
        }
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ServicoModel servico)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _servicoRepositorio.Adicionar(servico);
                    TempData["MensagemSucesso"] = "Peça cadastrada com sucesso";
                    return RedirectToAction("Index");
                }
                return View(servico);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível cadastrar, tente novamente, ERRO: {erro.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}
