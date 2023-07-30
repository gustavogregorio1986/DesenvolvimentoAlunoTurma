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

        public bool Apagar(int id)
        {
            AlunoModel alunodb = ListarPorId(id);

            if (alunodb == null) throw new System.Exception("Houve erro na deleção do alunio com turma");

            _bancoContext.Alunos.Remove(alunodb);
            _bancoContext.SaveChanges();

            return true;
        }

        public AlunoModel Atualizar(AlunoModel aluno)
        {
            AlunoModel alunodb = ListarPorId(aluno.Id);

            if (alunodb == null) throw new System.Exception("Houve um erro ao cadastra aluno e turma");

            alunodb.Nome = aluno.Nome;
            alunodb.Email = aluno.Email;
            alunodb.Escola = aluno.Escola;
            alunodb.Curso = aluno.Curso;
            alunodb.Situacao = aluno.Situacao;

            _bancoContext.Alunos.Update(alunodb);
            _bancoContext.SaveChanges();

            return alunodb;
        }

        public AlunoModel ListarPorId(int id)
        {
            return _bancoContext.Alunos.FirstOrDefault(x => x.Id == id);
        }

        public List<AlunoModel> ListarTodosAlunos()
        {
            return _bancoContext.Alunos.ToList();
        }
    }
}
