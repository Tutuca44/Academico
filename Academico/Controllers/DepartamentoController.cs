using Academico.Models;
using Academico.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Academico.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly IDepartamentoRepositorio _context;
        public DepartamentoController(IDepartamentoRepositorio departamentoRepositorio)
        {
            this._context = departamentoRepositorio;
        }
        public IActionResult Index()
        {
            List<TbDepartamento> departamentos = _context.BuscarTodos();
            return View(departamentos);
        }
        public IActionResult Criar()
        {
            int novoID = _context.ObterUltimoID() + 10; // Obtém o último ID e adiciona 10 para gerar o novo ID
            TbDepartamento departamento = new TbDepartamento { IdDepartamento = novoID };
            return View(departamento);
        }
        public IActionResult Editar(int id)
        {
            TbDepartamento departamento = _context.BuscarId(id);
            return View(departamento);
        }

       



        [HttpPost]

        public IActionResult Criar([Bind("IdDepartamento", "NmDepartamento", "Localizacao", "IdGerente")] TbDepartamento departamento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Adicionar(departamento);
                    TempData["MesagenSucesso"] = "Departamento Cadastro com Sucesso";
                    return RedirectToAction("Index");
                }
                return View(departamento);
            }
            catch (System.Exception erro)
            {
                TempData["MesagenErro"] = $"Ops, Não coseguimos cadastra o seu Departamento, detalher do erro: {erro.Message}";
                return RedirectToAction("Index");

            }

        }

        [HttpPost]
        public IActionResult Editar([Bind("IdDepartamento", "NmDepartamento", "Localizacao", "IdGerente", "FgAtivo")] TbDepartamento departamento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   _context.Alterar(departamento);
                    TempData["MesagenSucesso"] = "Departamento Cadastro com Sucesso";
                    return RedirectToAction("Index");
                }
                return View(departamento);
            }
            catch (System.Exception erro)
            {
                TempData["MesagenErro"] = $"Ops, Não coseguimos cadastra o seu Departamento, detalher do erro: {erro.Message}";
                return RedirectToAction("Index");

            }
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _context.Repositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar seu contato";



                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar o seu contato, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }




    }
}
