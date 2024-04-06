using EvoSocialAPI.Core.Account;
using EvoSocialAPI.Core.Database;
using EvoSocialAPI.Core.Session;
using Microsoft.AspNetCore.Identity;

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

        public static bool TokenExists(string token)
        {
            bool valid = false;
            EvoWebDatabase db = new EvoWebDatabase();
            string query = $"SELECT * FROM `test_users` WHERE `token` = '{token}'";

            List<string>[] result = db.ExecuteQuery(query);

            if (result[1].Count > 0)
            {
                valid = true;
            }
            else
            {
                valid = false;
            }

            return valid;

        }

        public static void DestroySession(string token)
        {
            EvoWebDatabase db = new EvoWebDatabase();
            string query = $"DELETE FROM `test_sessions` WHERE `token` = '{token}';";

            List<string>[] result = db.ExecuteQuery(query);
        }

        public static SessionIdentifier StartSession(string token)
        {

            if(!TokenExists(token)) { return new SessionIdentifier(); } // Token létezésének ellenőrzése

            DestroySession(token); // Összes létező session törlése

            string sessionid = SessionID.Generate();
            DateTime expire = DateTime.Now.AddDays(7);
            string expireString = Date.Unix(expire).ToString();

            EvoWebDatabase db = new EvoWebDatabase();
            string query = $"INSERT INTO `test_sessions` (`token`, `sessionid`, `expire`) VALUES ('{token}', '{sessionid}', '{expireString}');";

            // TODO: Esetleg később lekezlni, hogy fixen ne használt sessionidt generáljon

            List<string>[] result = db.ExecuteQuery(query);

            SessionIdentifier id = new SessionIdentifier(token, sessionid, true, expire);

            return id;

        }




        



    }
}
