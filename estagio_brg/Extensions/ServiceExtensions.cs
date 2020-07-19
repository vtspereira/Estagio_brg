using estagio_brg.Contracts;
using estagio_brg.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace estagio_brg.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
