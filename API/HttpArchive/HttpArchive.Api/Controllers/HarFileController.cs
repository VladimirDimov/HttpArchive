namespace Resource.Api.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using Services.Models;
    using System.Security.Claims;
    using System.Threading.Tasks;

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HarFileController : BaseController
    {
        private readonly IHarFileService harFileService;

        public HarFileController(IHarFileService harFileService)
        {
            this.harFileService = harFileService;
        }

        [HttpPost("upload")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> Upload([FromForm] HarFileUploadModel form)
        {
            await harFileService.UploadAsync(form, UserId);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var files = await harFileService.GetByUserIdAsync(UserId);

            return Ok(files);
        }

        [HttpGet("{fileId}")]
        public async Task<ActionResult> Get(string fileId)
        {
            var files = await harFileService.GetByFileIdAsync(fileId, UserId, UserEmail);

            return Ok(files);
        }

        [HttpPost("share")]
        public async Task<ActionResult> Share(FileShareModel form)
        {
            await harFileService.ShareAsync(form, UserId);

            return Ok();
        }

        [HttpGet("shared-with-me")]
        public async Task<ActionResult> GetSharedWithMe()
        {
            var sharedFiles = await harFileService.GetSharedWithMe(UserEmail);

            return Ok(sharedFiles);
        }
    }
}
