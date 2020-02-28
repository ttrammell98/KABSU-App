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
        public static void DatabaseLoad()
        {
            using (StreamReader sr = new StreamReader("C:/Users/e10d1/source/repos/KABSU-Inventory-App/Database Files/Database Sample Data/People.csv"))
            {
                string line;
                string[] lineTokens;
                string name;
                StringBuilder errorList = new StringBuilder();

                line = sr.ReadLine();

                while ((line = sr.ReadLine()) != null)
                {
                    name = "";

                    // Break down line into its constituent parts
                    if (line.Split(new string[] { "\"" }, StringSplitOptions.None).Count() > 1) 
                        name = line.Split(new string[] {"\""}, StringSplitOptions.None)[1];
                    lineTokens = line.Split(',');

                    // Add entry to database
                    if (name == "")
                        errorList.Append(InsertData.InsertPerson(Convert.ToInt32(lineTokens[0]), lineTokens[1], lineTokens[2], lineTokens[3], lineTokens[4]));
                    else
                        errorList.Append(InsertData.InsertPerson(Convert.ToInt32(lineTokens[0]), name, lineTokens[3], lineTokens[4], lineTokens[5]));
                }
            }
        }
    }
}
