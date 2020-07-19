using estagio_brg.Contracts;
using estagio_brg.Entities;

namespace estagio_brg.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IColaboradorRepository _colaborador;
        private IHabilidadeRepository _habilidade;
        private ITrilhaRepository _trilha;

        public IColaboradorRepository Colaborador
        {
            get
            {
                if (_colaborador == null)
                    _colaborador = new ColaboradorRepository(_repoContext);

                return _colaborador;
            }
        }
        public IHabilidadeRepository Habilidade
        {
            get
            {
                if (_habilidade == null)
                    _habilidade = new HabilidadeRepository(_repoContext);

                return _habilidade;
            }
        }
        public ITrilhaRepository Trilha
        {
            get
            {
                if (_trilha == null)
                    _trilha = new TrilhaRepository(_repoContext);

                return _trilha;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
