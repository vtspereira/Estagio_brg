using estagio_brg.Contracts;
using estagio_brg.Entities;
using estagio_brg.Entities.Models;

namespace estagio_brg.Repository
{
    public class TrilhaRepository : RepositoryBase<Trilha>, ITrilhaRepository
    {
        public TrilhaRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {

        }
    }
}
