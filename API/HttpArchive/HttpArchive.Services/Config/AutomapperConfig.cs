using AutoMapper;
using Services.Models;
using System;
using System.Linq;

namespace Services.Config
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            RegisterMapFrom();
            RegisterMapTo();
            RegisterCustomMappings();
        }

        private void RegisterMapTo()
        {
            var mapFromModels = typeof(HarFileModel).Assembly.GetExportedTypes()
                            .Where(t => t.GetInterfaces().Any(x =>
                                                              x.IsGenericType &&
                                                              x.GetGenericTypeDefinition() == typeof(IMapTo<>)));

            foreach (var sourceType in mapFromModels)
            {
                var mapFromInterfaceType = sourceType.GetInterfaces().FirstOrDefault(x =>
                                                                              x.IsGenericType &&
                                                                              x.GetGenericTypeDefinition() == typeof(IMapTo<>));

                var targetType = mapFromInterfaceType.GetGenericArguments().First();

                CreateMap(sourceType, targetType);
            }
        }

        private void RegisterMapFrom()
        {
            var mapFromModels = typeof(HarFileModel).Assembly.GetExportedTypes()
                            .Where(t => t.GetInterfaces().Any(x =>
                                                              x.IsGenericType &&
                                                              x.GetGenericTypeDefinition() == typeof(IMapFrom<>)));

            foreach (var targetType in mapFromModels)
            {
                var mapFromInterfaceType = targetType.GetInterfaces().FirstOrDefault(x =>
                                                                              x.IsGenericType &&
                                                                              x.GetGenericTypeDefinition() == typeof(IMapFrom<>));

                var sourceType = mapFromInterfaceType.GetGenericArguments().First();

                CreateMap(sourceType, targetType);
            }
        }

        private void RegisterCustomMappings()
        {
            var mapFromModels = typeof(HarFileModel).Assembly.GetExportedTypes()
                            .Where(t => t.GetInterfaces().Any(x => x == typeof(IHaveCustomMappings)));

            foreach (var modelType in mapFromModels)
            {
                var modelInstance = Activator.CreateInstance(modelType) as IHaveCustomMappings;
                modelInstance.CreateCustomMapping(this);
            }
        }
    }
}
