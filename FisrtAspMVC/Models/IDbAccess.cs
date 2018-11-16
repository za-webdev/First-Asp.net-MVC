using System.Collections.Generic;

namespace FisrtAspMVC.Models
{
    public interface IDbAccess
    {
        Admin SelectAdmin(string command, string connectionString);
       List<Student> SelectStudent(string command, string connectionString);


    }
}