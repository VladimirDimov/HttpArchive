using Data.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IHarFileRepository
    {
        Task<IEnumerable<HarFile>> ByUserIdAsync(string userId);
        Task CreateAsync(HarFile dto);
        Task UpdateAsync(HarFile dto);
        Task<HarFile> ByIdAsync(string id);
        Task<IEnumerable<HarFile>> SharedFiles(string userEmail);
    }
}