namespace EvoSocialAPI.Core.Responses
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public bool Error { get; set; }
        public string Response { get; set; }
        public string SessionID { get; set; }

    }
}
