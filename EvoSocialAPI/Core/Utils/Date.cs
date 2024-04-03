namespace EvoSocialAPI.Core.Utils
{
    public class Date
    {

        public static long Unix()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }

    }
}
