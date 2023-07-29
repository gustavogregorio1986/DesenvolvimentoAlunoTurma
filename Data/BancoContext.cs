using Microsoft.EntityFrameworkCore;
using ProjetoTurma.Models;

namespace ProjetoTurma.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<AlunoModel> Alunos { get; set; }
    }
}
