using Empresa.App.Application.Interface.UseCases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Empresa.App.Application.UseCases
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<ICitaApplication, CitaApplication>();
           
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
