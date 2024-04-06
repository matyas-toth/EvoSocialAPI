namespace EvoSocialAPI.Core.Session
{
    public class SessionIdentifier
    {

        public string Token;

        public string SessionID;

        public bool Valid;

        public DateTime Expire;

        public SessionIdentifier(string token, string sessionId, bool valid, DateTime expire)
        {
            this.Token = token;
            this.SessionID = sessionId;
            this.Valid = valid;
            this.Expire = expire;
        }

        public SessionIdentifier(string token, string sessionId, bool valid)
        {
            this.Token = token;
            this.SessionID = sessionId;
            this.Valid = valid;
            this.Expire = DateTime.Now.AddDays(7);
        }

        public SessionIdentifier()
        {
            this.Token = "";
            this.SessionID = "";
            this.Valid = false;
            this.Expire = DateTime.Now;
        }

        public string GetSessionID() { return SessionID; }

        public bool IsValid()
        {
            return this.Valid;
        }

    }
}
