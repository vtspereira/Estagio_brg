using estagio_brg.Contracts;
using estagio_brg.Entities;
using estagio_brg.Entities.Models;

namespace estagio_brg.Repository
{
    public class ColaboradorRepository : RepositoryBase<Colaborador>, IColaboradorRepository
    {
        public ColaboradorRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {

        }
    }
}
