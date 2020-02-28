using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace WpfApp
{
    class InsertData
    {
        public static string InsertPerson(int personID, string name, string city, string state, string country)
        {
            string connectionString = "Server=localhost;Database=kabsu; User ID = appuser; Password = test; Integrated Security=true";
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    using (var command = new MySqlCommand("kabsu.InsertPerson", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", personID);
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@City", city);
                        command.Parameters.AddWithValue("@State", state);
                        command.Parameters.AddWithValue("@Country", country);

                        connection.Open();

                        var reader = command.ExecuteReader();

                        reader.Read();
                    }
                }
                return "";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public void InsertPerson(string name, string city, string state, string country)
        {
            string connectionString = "Server=localhost;Database=kabsu; User ID = appuser; Password = test; Integrated Security=true";
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    using (var command = new MySqlCommand("kabsu.InsertPerson", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@City", city);
                        command.Parameters.AddWithValue("@State", state);
                        command.Parameters.AddWithValue("@Country", country);

                        connection.Open();

                        var reader = command.ExecuteReader();

                        while (reader.Read())
                        {

                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }
    }
}
