using Data.DTO;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public class HarFileRepository : IHarFileRepository
    {
        private readonly IHttpArchiveDbContext dbContext;

        public HarFileRepository(IHttpArchiveDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(HarFile dto)
        {
            dto.CreatedOn = DateTime.UtcNow;

            await dbContext.HarFiles.InsertOneAsync(dto);
        }

        public async Task<IEnumerable<HarFile>> ByUserIdAsync(string userId)
        {
            return await dbContext.HarFiles.Find<HarFile>(f => f.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<HarFile>> SharedFiles(string userEmail)
        {
            return await dbContext.HarFiles.Find<HarFile>(f => f.SharedWith.Contains(userEmail)).ToListAsync();
        }

        public async Task<HarFile> ByIdAsync(string id)
        {
            return (await dbContext.HarFiles.FindAsync<HarFile>(f => f.Id == id)).FirstOrDefault();
        }

        public async Task UpdateAsync(HarFile dto)
        {
            await dbContext.HarFiles.ReplaceOneAsync(f => f.Id == dto.Id, dto);
        }
    }
}
