namespace estagio_brg.Contracts
{
    public interface IRepositoryWrapper
    {
        IColaboradorRepository Colaborador { get; }

        IHabilidadeRepository Habilidade { get;  }

        ITrilhaRepository Trilha { get; }

        void Save();
    }
}
