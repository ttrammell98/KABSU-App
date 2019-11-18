using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;


namespace WpfApp
{
    class Sql
    {
        public String thing = "ApplicationIntent=ReadWrite;server=tcp:localhost, 3306";

        public void yeehaw(){
            using (SqlConnection connection = new SqlConnection(thing))
            {
                connection.Open();
            }

        }
    }
}
