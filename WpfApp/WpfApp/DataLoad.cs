using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    /// <summary>
    /// Class to automate filling the database while providing an output of failed entries
    /// </summary>
    class DataLoad
    {
        /// <summary>
        /// Primary method to be called
        /// </summary>
        public void DatabaseLoad()
        {
            using (StreamReader sr = new StreamReader("C:/Users/e10d1/source/repos/KABSU - Inventory - App/People.csv"))
            {
                string line;
                string[] lineTokens;

                while ((line = sr.ReadLine()) == null)
                {
                    // Break down line into its constituent parts
                    lineTokens = line.Split(',');

                    // Add entry to database

                }
            }
        }
    }
}
