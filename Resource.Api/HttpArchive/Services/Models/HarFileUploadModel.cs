using Microsoft.AspNetCore.Http;

namespace Services.Models
{
    public class HarFileUploadModel
    {
        public string FilePath { get; set; }

        public IFormFile FileContent { get; set; }
    }
}
