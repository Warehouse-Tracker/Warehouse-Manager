using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WarehouseManager.Service.Infrastructure;

namespace WarehouseManager.Web.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            Type transientServiceInterfaceType = typeof(ITransientService);
            Type singletonServiceInterfaceType = typeof(ISingletonService);
            Type scopedServiceInterfaceType = typeof(IScopedService);

            var serviceTypes = transientServiceInterfaceType.Assembly
                .GetExportedTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Select(t => new
                {
                    Service = t.GetInterface($"I{t.Name}"),
                    Implementation = t
                })
                .Where(t => t.Service != null);

            foreach (var serviceType in serviceTypes)
            {
                if (transientServiceInterfaceType.IsAssignableFrom(serviceType.Service))
                {
                    services.AddTransient(serviceType.Service, serviceType.Implementation);
                }
                else if (singletonServiceInterfaceType.IsAssignableFrom(serviceType.Service))
                {
                    services.AddSingleton(serviceType.Service, serviceType.Implementation);
                }
                else if (scopedServiceInterfaceType.IsAssignableFrom(serviceType.Service))
                {
                    services.AddScoped(serviceType.Service, serviceType.Implementation);
                }
            }

            return services;
        }
    }
}
