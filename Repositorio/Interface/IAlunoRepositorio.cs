using ProjetoTurma.Models;
using System.Collections.Generic;

namespace ProjetoTurma.Repositorio.Interface
{
    public interface IAlunoRepositorio
    {
        AlunoModel Adicionar(AlunoModel aluno);

        List<AlunoModel> ListarTodosAlunos();

        AlunoModel ListarPorId(int id);

        AlunoModel Atualizar(AlunoModel aluno);

        bool Apagar(int id);
    }
}
