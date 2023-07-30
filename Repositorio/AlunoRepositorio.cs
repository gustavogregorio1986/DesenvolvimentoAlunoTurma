using ProjetoTurma.Data;
using ProjetoTurma.Models;
using ProjetoTurma.Repositorio.Interface;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoTurma.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public AlunoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public AlunoModel Adicionar(AlunoModel aluno)
        {
            _bancoContext.Alunos.Add(aluno);
            _bancoContext.SaveChanges();

            return aluno;
        }

        public List<AlunoModel> ListarTodosAlunos()
        {
            return _bancoContext.Alunos.ToList();
        }
    }
}
