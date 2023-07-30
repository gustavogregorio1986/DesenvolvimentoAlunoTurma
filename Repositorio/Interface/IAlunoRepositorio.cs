using ProjetoTurma.Models;
using System.Collections.Generic;

namespace ProjetoTurma.Repositorio.Interface
{
    public interface IAlunoRepositorio
    {
        AlunoModel Adicionar(AlunoModel aluno);

        List<AlunoModel> ListarTodosAlunos();
    }
}
