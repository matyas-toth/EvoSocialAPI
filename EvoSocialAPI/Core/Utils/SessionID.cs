namespace EvoSocialAPI.Core.Utils
{
    public class SessionID
    {

        const string SessionIDChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-";
        const int SessionIDLength = 32;

        public static string Generate()
        {
            Random random = new Random();

            return new string(Enumerable.Repeat(SessionIDChars, SessionIDLength)
        .Select(s => s[random.Next(s.Length)]).ToArray());

        }

    }
}
