using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class Dependencies
    {
        public static IServiceCollection AddData(this IServiceCollection services)
        {
            services.Scan(scan => scan
              .FromAssemblyOf<AssemblyLocator>()
                .AddClasses(classes => classes.InNamespaces(typeof(AssemblyLocator).Namespace))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

            return services;
        }

        private class AssemblyLocator { };
    }
}
