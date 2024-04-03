using EvoSocialAPI.Core.Account;
using EvoSocialAPI.Core.Responses;
using EvoSocialAPI.Core.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvoSocialAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {

            _logger = logger;

        }

        [HttpGet(Name = "Login")]
        public LoginResponse Get(string username, string password)
        {
            AccountIdentifier acc = AccountUtils.GetAccount(username, password);

            string response = "";

            if(!acc.IsValid())
            {
                response = "invalid-account";
            }

            return new LoginResponse { Token = acc.GetToken(), Error = !acc.IsValid(), Response = response, SessionID = "" };
        }

    }
}
