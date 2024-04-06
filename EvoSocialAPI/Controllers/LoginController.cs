using EvoSocialAPI.Core.Account;
using EvoSocialAPI.Core.Responses;
using EvoSocialAPI.Core.Session;
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
            AccountIdentifier account = AccountUtils.GetAccount(username, password);

            string response = "";
            bool error = false;

            if(!account.IsValid())
            {
                response = "invalid-account";
                error = true;
            }

            Session session = new Session(account);
            SessionIdentifier sessionID = session.Start();

            if(!sessionID.IsValid())
            {
                response = "invalid-account";
                error = true;
            }


            return new LoginResponse { Error = error, Response = response, SessionID = sessionID.GetSessionID() };
        }

    }
}
