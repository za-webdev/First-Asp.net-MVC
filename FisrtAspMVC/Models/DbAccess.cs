using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FisrtAspMVC.Models
{
    public class DbAccess : IDbAccess
    {
        public Admin SelectAdmin(string command, string connectionString)
        {
            var admin = new Admin();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand objSqlCommand = new SqlCommand(command, sqlConnection))
                {
                    using (var dataReader = objSqlCommand.ExecuteReader())
                    {
                        if (dataReader.Read() == true)
                        {
                            admin.Id = dataReader.GetInt32(0);
                            admin.Name = dataReader.GetString(1);
                            //admin.IsSuperAdmin = dataReader.GetInt32(2);
                            return admin;
                        }

                    }
                }
                sqlConnection.Close();
            }
            return null;
        }

        public List<Student> SelectStudent(string command, string connectionString)
        {
            List<Student> listOfStudents = new List<Student>();
            var student = new Student();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand objSqlCommand = new SqlCommand(command, sqlConnection))
                {
                    using (var dataReader = objSqlCommand.ExecuteReader())
                    {
                        while (dataReader.Read() == true)
                        {
                            student.Id = dataReader.GetInt32(0);
                            student.Name = dataReader.GetString(1);
                            student.Description = dataReader.GetString(2);
                            student.StudentCode = dataReader.GetString(3);
                            student.CreatedAt = dataReader.GetDateTime(4);
                            listOfStudents.Add(student);
                            return listOfStudents;
                        }

                    }
                }
                sqlConnection.Close();
            }
            return null;
        }
    }
}


