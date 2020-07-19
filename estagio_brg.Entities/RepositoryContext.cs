using estagio_brg.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace estagio_brg.Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }

        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Habilidade> Habilidades { get; set; }
        public DbSet<Trilha> Trilhas { get; set; }

    }
}
