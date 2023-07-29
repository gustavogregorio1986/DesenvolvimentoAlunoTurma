using ProjetoTurma.Data;
using ProjetoTurma.Models;
using ProjetoTurma.Repositorio.Interface;

namespace ProjetoTurma.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public Alunorepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public AlunoModel Adicionar(AlunoModel aluno)
        {
            _bancoContext.Alunos.Add(aluno);
            _bancoContext.SaveChanges();

            return aluno;
        }
    }
}
