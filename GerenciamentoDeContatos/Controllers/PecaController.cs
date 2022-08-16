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
    public class PecaController : Controller
    {

        private readonly IPecaRepositorio _pecaRepositorio;
        public PecaController(IPecaRepositorio pecaRepositorio)
        {
            _pecaRepositorio = pecaRepositorio;
        }
        public IActionResult Index()
        {
            List<PecaModel> contatos = _pecaRepositorio.BuscarTodos();
            return View(contatos);
        }
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(PecaModel peca)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _pecaRepositorio.Adicionar(peca);
                    TempData["MensagemSucesso"] = "Peça cadastrada com sucesso";
                    return RedirectToAction("Index");
                }
                return View(peca);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível cadastrar, tente novamente, ERRO: {erro.Message}";
                return RedirectToAction("Index");
            }

        }
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _pecaRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possível apagar seu contato";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível apagar, tente novamente, ERRO: {erro.Message}";
                return RedirectToAction("Index");
            }

        }
        public IActionResult ApagarConfirmacao(int id)
        {
            PecaModel contato = _pecaRepositorio.ListarPorId(id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Alterar(PecaModel peca)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _pecaRepositorio.Atualizar(peca);
                    TempData["MensagemSucesso"] = "Peça atualizada com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", peca);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível atualizar, tente novamente, ERRO: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Editar(int id)
        {
            PecaModel peca = _pecaRepositorio.ListarPorId(id);
            return View(peca);
        }
    }
}
