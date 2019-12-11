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
        public List<SearchResult> retrieveData(string owner, string breed, string animalName, string code, string canNum, string town, string state)
        {
            string connectionString = "tcp:localhost; Integrated Security=true";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("kabsu.RetrieveData", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.AddWithValue("Owner", owner);
                        command.Parameters.AddWithValue("Breed", breed);
                        command.Parameters.AddWithValue("AnimalName", animalName);
                        command.Parameters.AddWithValue("Code", code);
                        command.Parameters.AddWithValue("CanNum", canNum);
                        command.Parameters.AddWithValue("Town", town);
                        command.Parameters.AddWithValue("State", state);
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
                               reader.GetString(reader.GetOrdinal("Town")),
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
