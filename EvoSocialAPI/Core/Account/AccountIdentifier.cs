namespace EvoSocialAPI.Core.Account
{
    public class AccountIdentifier
    {

        public string Token;

        public bool Valid;

        public AccountIdentifier(string token, bool valid)
        {
            this.Token = token;
            this.Valid = valid;
        }

        public bool IsValid()
        {
            return this.Valid;
        }

        public string GetToken()
        {
            return this.Token;
        }


    }
}
