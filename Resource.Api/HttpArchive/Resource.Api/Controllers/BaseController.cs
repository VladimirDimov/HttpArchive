using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Resource.Api.Controllers
{
    [Authorize]
    public class BaseController : ControllerBase
    {
        public string UserId => this.Request.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        public string UserEmail => this.Request.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
    }
}
