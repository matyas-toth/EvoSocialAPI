using System;

namespace EvoSocialAPI.Core.Utils
{
    public class Token
    {

        const string TokenChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789.-_";
        const int TokenLength = 256;

        public static string Generate()
        {
            Random random = new Random();

            return new string(Enumerable.Repeat(TokenChars, TokenLength)
        .Select(s => s[random.Next(s.Length)]).ToArray());

        }
    }
}
