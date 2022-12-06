using ECommerce.Common.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Common.Application.Implementacion
{
    public static class ServiceExtensions
    {
        public static void AddApplication(this IServiceCollection Services)
        {
            Services.AddScoped<IConceptoRepository, ConceptoRepository>();
            Services.AddScoped<IBodegaRepository, BodegaRepository>();
        }
    }
}
