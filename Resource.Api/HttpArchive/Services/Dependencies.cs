using Data;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Services
{
    public static class Dependencies
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.Scan(scan => scan
              .FromAssemblyOf<HarFileService>()
                .AddClasses(classes => classes.InNamespaces(typeof(HarFileService).Namespace))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

            services.AddData();

            services.AddAutoMapper(typeof(HarFileService).Assembly);

            return services;
        }
    }
}
