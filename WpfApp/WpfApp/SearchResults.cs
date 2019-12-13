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
    public class SearchResults
    {
        public List<SearchResult> retrieveData(SearchTerm st)
        {
            string connectionString = "Server=localhost;Database=kabsu; User ID = appuser; Password = test; Integrated Security=true";
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    using (var command = new MySqlCommand("kabsu.RetrieveData", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                    

                        command.Parameters.AddWithValue("@Owner", st.Owner);
                        command.Parameters.AddWithValue("@Breed", st.Breed);
                        command.Parameters.AddWithValue("@AnimalName", st.AnimalName);
                        command.Parameters.AddWithValue("@Code", st.Code);
                        command.Parameters.AddWithValue("@CanNum", st.CanNum);
                        command.Parameters.AddWithValue("@Town", st.Town);
                        command.Parameters.AddWithValue("@State", st.State);
                        connection.Open();

                        var reader = command.ExecuteReader();

                        var resultList = new List<SearchResult>();

                        while (reader.Read())
                        {
                            resultList.Add(new SearchResult(
                               reader.GetBoolean(reader.GetOrdinal("Valid")).ToString(),
                               reader.GetString(reader.GetOrdinal("CanNum")),
                               reader.GetString(reader.GetOrdinal("AnimalID")),
                               reader.GetString(reader.GetOrdinal("CollDate")),
                               reader.GetString(reader.GetOrdinal("NumUnits")),
                               reader.GetString(reader.GetOrdinal("AnimalName")),
                               reader.GetString(reader.GetOrdinal("Breed")),
                               reader.GetString(reader.GetOrdinal("RegNum")),
                               reader.GetString(reader.GetOrdinal("PersonName")),
                               reader.GetString(reader.GetOrdinal("City")),
                               reader.GetString(reader.GetOrdinal("State"))));
                        }

                        return resultList;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to connect to database.");
                return new List<SearchResult>();
            }
        }
    }
}
