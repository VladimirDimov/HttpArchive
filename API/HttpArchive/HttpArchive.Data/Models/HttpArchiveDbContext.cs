using Data.DTO;
using Data.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Data.Models
{
    public class HttpArchiveDbContext : IHttpArchiveDbContext
    {
        private IMongoDatabase database;

        private readonly string harFilesCollectionName;

        public HttpArchiveDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetSection("DatabaseSettings:ConnectionString").Value);
            database = client.GetDatabase(configuration.GetSection("DatabaseSettings:DatabaseName").Value);
            harFilesCollectionName = configuration.GetSection("DatabaseSettings:HarFilesCollectionName").Value;
        }

        public IMongoCollection<HarFile> HarFiles => database.GetCollection<HarFile>(harFilesCollectionName);
    }
}
