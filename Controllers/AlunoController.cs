using Microsoft.AspNetCore.Mvc;

namespace ProjetoTurma.Controllers
{
    public class AlunoController : Controller
    {
        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Consultar()
        {
            return View();
        }
    }
}
