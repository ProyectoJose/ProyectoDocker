using Empresa.App.Cross.Common.LogAdapter;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Empresa.App.Cross.Common
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddCrossCommon(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddScoped(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>));
            return services;
        }
    }
}
