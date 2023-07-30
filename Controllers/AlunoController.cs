using Microsoft.AspNetCore.Mvc;
using ProjetoTurma.Models;
using ProjetoTurma.Repositorio.Interface;
using System.Collections.Generic;

namespace ProjetoTurma.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

        public AlunoController(IAlunoRepositorio alunoRepositorio)
        {
            this._alunoRepositorio = alunoRepositorio;
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            AlunoModel aluno = _alunoRepositorio.ListarPorId(id);
            return View(aluno);
        }

        [HttpPost]
        public IActionResult Cadastrar(AlunoModel aluno)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _alunoRepositorio.Adicionar(aluno);
                    TempData["MensagemSucesso"] = "Aluno e turma cadastrada com sucesso.";
                    return RedirectToAction("Consultar");
                }

                return View(aluno);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possivel cadastrar aluno e sua turma, tente novamente, erro: {erro.Message}";
                return RedirectToAction("Consultar");
            }
        }

        public IActionResult Consultar()
        {
            List<AlunoModel> listar = _alunoRepositorio.ListarTodosAlunos();
            return View(listar);
        }

        public IActionResult Editar(int id)
        {
            AlunoModel aluno = _alunoRepositorio.ListarPorId(id);
            return View(aluno);
        }

        [HttpPost]
        public IActionResult Alterar(AlunoModel aluno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _alunoRepositorio.Atualizar(aluno);
                    TempData["MensagemSucesso"] = "Aluno e turma atualizado com sucesso.";
                    return RedirectToAction("Consultar");
                }
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possivel atualizado aluno e sua turma, tente novamente, erro: {erro.Message}";
                return RedirectToAction("Consultar");
            }

            return View("Editar", aluno);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _alunoRepositorio.Apagar(id);

                if(apagado)
                {
                    TempData["MensagemSucesso"] = "Aluno e turma atualizado com sucesso.";
                }
                else
                {
                    TempData["MensagemErro"] = "Aluno e turma não foi atualizado com sucesso.";
                }

                return RedirectToAction("Consultar");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possivel atualizado aluno e sua turma, tente novamente, erro: {erro.Message}";
                return RedirectToAction("Consultar");
            }
        }
    }
}
