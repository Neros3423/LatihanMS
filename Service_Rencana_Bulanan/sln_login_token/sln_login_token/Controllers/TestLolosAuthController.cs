using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace sln_login_token.Controllers
{
    [Route("api/Test")]
    [ApiController]
    public class TestLolosAuthController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public string GetVal()
        {
            return "berhasin auth";
        }
    }
}
