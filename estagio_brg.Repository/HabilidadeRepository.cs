using estagio_brg.Contracts;
using estagio_brg.Entities;
using estagio_brg.Entities.Models;

namespace estagio_brg.Repository
{
    public class HabilidadeRepository : RepositoryBase<Habilidade>, IHabilidadeRepository
    {
        public HabilidadeRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {

        }
    }
}
