using ClientesApi.Application.Interfaces;
using ClientesApi.Application.Services;
using ClientesApi.Domain.Interfaces.Repositories;
using ClientesApi.Domain.Interfaces.Services;
using ClientesApi.Domain.Services;
using ClientesApi.InfraStructure.Repositories;

namespace ClientesApi.Services.Extensions
{
    public static class DependencyInjectionExtension
    {

        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IClienteAppService, ClienteAppService>();
            services.AddTransient<IClienteDomainService, ClienteDomainService>();
            services.AddTransient<IClienteRepository, ClienteRepository>();


            return services;    
        }
    }
}
