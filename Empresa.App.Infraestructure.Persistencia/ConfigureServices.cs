using Empresa.App.Application.Interface.Persistence.Repositories;
using Empresa.App.Infraestructure.Persistencia.Context.Dapper;
using Empresa.App.Infraestructure.Persistencia.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Empresa.App.Infraestructure.Persistencia
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<DapperContext>();

            services.AddScoped<ICitaRepository, CitaRepository>();

            return services;
        }
    }
 
}
