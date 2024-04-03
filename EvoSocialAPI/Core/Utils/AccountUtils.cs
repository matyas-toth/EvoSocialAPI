using EvoSocialAPI.Core.Account;
using EvoSocialAPI.Core.Database;

namespace EvoSocialAPI.Core.Utils
{
    public class AccountUtils
    {

        public static bool UsernameExists(string username)
        {
            EvoWebDatabase db = new EvoWebDatabase();
            string query = $"SELECT * FROM `test_users` WHERE `username` = '{username}'";

            List<string>[] result = db.ExecuteQuery(query);

            if (result[1].Count > 0)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public static bool EmailExists(string email)
        {
            EvoWebDatabase db = new EvoWebDatabase();
            string query = $"SELECT * FROM `test_users` WHERE `email` = '{email}'";

            List<string>[] result = db.ExecuteQuery(query);

            if (result[1].Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool AccountExists(string username, string password)
        {

            string passwordhash = Hash.EncryptSHA512(password);

            EvoWebDatabase db = new EvoWebDatabase();
            string query = $"SELECT * FROM `test_users` WHERE `username` = '{username}' AND `passwordhash` = `{passwordhash}`";

            List<string>[] result = db.ExecuteQuery(query);

            if (result[1].Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static AccountIdentifier GetAccount(string username, string password)
        {

            string passwordhash = Hash.EncryptSHA512(password);
            bool valid;
            string token = "";

            EvoWebDatabase db = new EvoWebDatabase();
            string query = $"SELECT * FROM `test_users` WHERE `username` = '{username}' AND `passwordhash` = '{passwordhash}'";

            List<string>[] result = db.ExecuteQuery(query);

            if (result[1].Count > 0)
            {
                valid = true;
                string row = result[1][0];
                string[] data = row.Split();
                token = data[6];
            }
            else
            {
                valid = false;
            }

            return new AccountIdentifier(token, valid);

        }



        



    }
}
