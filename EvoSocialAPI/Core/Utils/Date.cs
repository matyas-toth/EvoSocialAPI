namespace EvoSocialAPI.Core.Utils
{
    public class Date
    {

        public static long Unix()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }

        public static long Unix(DateTime date)
        {
            DateTimeOffset offset = new DateTimeOffset(date);
            return offset.ToUnixTimeSeconds();

        }

    }
}
