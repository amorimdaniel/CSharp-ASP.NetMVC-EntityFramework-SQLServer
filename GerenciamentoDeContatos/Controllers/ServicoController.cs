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
        public IActionResult ApagarConfirmacao(int id)
        {
            ServicoModel servico = _servicoRepositorio.ListarPorId(id);
            return View(servico);
        }
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _servicoRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Serviço apagado com sucesso";
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
        public IActionResult Editar(int id)
        {
            ServicoModel servico = _servicoRepositorio.ListarPorId(id);
            return View(servico);
        }

        [HttpPost]
        public IActionResult Alterar(ServicoModel servico)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _servicoRepositorio.Atualizar(servico);
                    TempData["MensagemSucesso"] = "Serviço atualizado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", servico);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível atualizar, tente novamente, ERRO: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
