using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FisrtAspMVC.Models
{
    public class User:DbContext
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Password { get; set; }

        public List<User> UserList = new List<User>();

        public string ConnectionString;

        //private readonly IHttpContextAccessor _httpContextAccessor;
        //private ISession _session => _httpContextAccessor.HttpContext.Session;

        public User()
        {
            ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=MVCDB;Integrated Security=True";
        }
        //public User(IHttpContextAccessor httpContextAccessor)
        //{
        //    _httpContextAccessor = httpContextAccessor;
        //}
        public Boolean validLogin(string Name,string Password )
        {
            using (SqlConnection objSqlCommand = new SqlConnection (ConnectionString) )
            if(Name == "admin" )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<User> GetAllUsers()
        {
            UserList.Add(new User() { Id = 1,Name= "zoya"});
            UserList.Add(new User() { Id = 1, Name = "John" });
            UserList.Add(new User() { Id = 1, Name = "Kim" });
            UserList.Add(new User() { Id = 1, Name = "lola" });

            return UserList;

        }
    }
}
