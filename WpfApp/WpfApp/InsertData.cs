using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace WpfApp
{
    class InsertData
    {
        public void InsertPerson(int personID, string name, string city, string state, string country)
        {
            string connectionString = "Server=localhost;Database=kabsu; User ID = appuser; Password = test; Integrated Security=true";
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    
                }
            }
            catch (Exception e)
            {

            }
        }
    }
}
