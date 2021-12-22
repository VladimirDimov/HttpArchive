using Data.DTO;
using MongoDB.Driver;

namespace Data.Interfaces
{
    public interface IHttpArchiveDbContext
    {
        IMongoCollection<HarFile> HarFiles { get; }
    }
}