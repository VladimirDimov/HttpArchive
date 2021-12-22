using Services.Models;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IHarFileService
    {
        Task<HarFileModel> GetByFileIdAsync(string fileId, string userId, string userEmail);
        Task<FolderModel> GetByUserIdAsync(string userId);
        Task UploadAsync(HarFileUploadModel form, string user);
        Task ShareAsync(FileShareModel form, string userId);
        Task<FolderModel> GetSharedWithMe(string userEmail);
    }
}