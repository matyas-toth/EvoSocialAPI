using MySql.Data.MySqlClient;

namespace EvoSocialAPI.Core.Database
{
    public class EvoWebDatabase
    {

        private MySqlConnection connection;
        private string host = "-";
        private string db = "-";
        private string username = "-";
        private string password = "-";

        public EvoWebDatabase()
        {
            string connectionString = $"server={host};database={db};uid={username};pwd={password}";
            connection = new MySqlConnection(connectionString);
        }

        private bool OpenConnection()
        {
            try
            {

                connection.Open();
                return true;

            }
            catch (MySqlException ex) {

                return false;
            
            }
        }

        private bool CloseConnection()
        {
            try
            {

                connection.Close();
                return true;

            }
            catch (MySqlException ex)
            {

                return false;

            }
        }

        public List<string>[] ExecuteQuery(string query)
        {
            List<string>[] result = new List<string>[2];
            result[0] = new List<string>();
            result[1] = new List<string>();

            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();


                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    result[0].Add(dataReader.GetName(i));
                }


                while (dataReader.Read())
                {
                    string row = "";
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        row += dataReader[i].ToString() + " ";
                    }
                    result[1].Add(row);
                }

                dataReader.Close();
                this.CloseConnection();
                return result;
            }
            else
            {
                return result;
            }
        }



    }
}
