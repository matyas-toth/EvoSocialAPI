using EvoSocialAPI.Core.Exceptions;
using EvoSocialAPI.Core.Register;
using EvoSocialAPI.Core.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvoSocialAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {

        private readonly ILogger<RegisterController> _logger;

        public RegisterController(ILogger<RegisterController> logger) { 

            _logger = logger;

        }

        [HttpGet(Name = "Register")]
        public RegisterResponse Get(string firstname, string lastname, string email, string username, string password)
        {

            RegisterAccount tryAcc = new RegisterAccount { FirstName = firstname, LastName = lastname, Email = email, Username = username, Password = password};

            string response = "success";
            bool error = false;
            string sessionid = "";

            try
            {
                Register.CreateAccount(tryAcc);
            } catch (RegisterException ex)
            {
                response = ex.Message;
                error = true;
            }

            return new RegisterResponse { Error = error, Response = response, SessionID = sessionid };
        }

    }
}
