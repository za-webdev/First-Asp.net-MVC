using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using FisrtAspMVC.Models;

namespace DbAccess 
{
    public class DbAccess : IDbAccess
    {
        public Admin Select (string command , string connectionString)
        {
            var admin = new Admin();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand objSqlCommand = new SqlCommand(command, sqlConnection))
                {
                    using (var dataReader = objSqlCommand.ExecuteReader())
                    {
                        if(dataReader.Read() == true)
                        {
                            return admin;
                        }
                        return null;
                    }
                }
            }
        }
    }
}
