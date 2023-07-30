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
    }
}
