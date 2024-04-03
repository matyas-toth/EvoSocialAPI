using EvoSocialAPI.Core.Database;
using EvoSocialAPI.Core.Exceptions;
using EvoSocialAPI.Core.Utils;

namespace EvoSocialAPI.Core.Register
{
    public class Register
    {

        public static void CreateAccount(RegisterAccount acc)
        {
            string pwHash = Hash.EncryptSHA512(acc.Password);
            string lastActivitiy = Date.Unix().ToString();
            string token = Token.Generate();

            if(AccountUtils.UsernameExists(acc.Username))
            {
                throw new RegisterException("username-unavailable");
            }

            if(AccountUtils.EmailExists(acc.Email))
            {
                throw new RegisterException("email-unavailable");
            }

            try
            {
                EvoWebDatabase db = new EvoWebDatabase();

                List<string>[] result = db.ExecuteQuery($"INSERT INTO `test_users` (`username`, `email`, `firstname`, `lastname`, `passwordhash`, `lastactivity`, `token`) VALUES ('{acc.Username}', '{acc.Email}', '{acc.FirstName}', '{acc.LastName}', '{pwHash}', '{lastActivitiy}', '{token}');");
            } catch (Exception ex)
            {
                throw new RegisterException("error-while-inserting-into-db");
            }



        }

    }
}
