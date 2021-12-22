using AutoMapper;

namespace Services.Config
{
    public interface IHaveCustomMappings
    {
        void CreateCustomMapping(Profile profile);
    }
}