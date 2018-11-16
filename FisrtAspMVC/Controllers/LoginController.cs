using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FisrtAspMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using System.Web;

namespace FisrtAspMVC.Controllers
{
    public class LoginController : Controller
    {
        public string connectionString;
        private IDbAccess _dbAccess;
        public LoginController(IDbAccess dbAccess = null)
        {
            connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=MVCDB;Integrated Security=True";
            _dbAccess = dbAccess ?? new DbAccess();
        }
        public IActionResult Index()
        {
            return View("Login");
        }

        [ActionName("index")]
        [HttpPost]
        public IActionResult Login(Admin admin)
        {
            string name = Request.Form["Name"];
            string pass = Request.Form["Password"];
            var command = String.Format("Select Id,Name,Password from Admins where Name='{0}' and Password ='{1}' ",name,pass );

           var obj = _dbAccess.SelectAdmin(command, connectionString);
           if(obj != null)
            {
                HttpContext.Session.SetString("Name", obj.Name);
                HttpContext.Session.SetInt32("Id",obj.Id );
                return Dashboard();
            }
            else
            {
                ViewData["invalid"] = "Inavlid user";
                ViewBag.Name = name;
            }
            return View("Login");
        }
        public IActionResult Dashboard()
        {
            ViewBag.Id = HttpContext.Session.GetInt32("Id");
            ViewBag.Name = HttpContext.Session.GetString("Name");
            if (ViewBag.Id == null)
            {
                return Redirect("~/Login/Index");
            }
            var command = String.Format("Select * from students");
            var students = _dbAccess.SelectStudent(command, connectionString);

            return View("Dashboard",students);
        }
        //public IActionResult Show()
        //{
        //    if (HttpContext.Session.GetString("Name") == null)
        //    {
        //        return Redirect("~/Login/Index");
        //    }

        //    ViewBag.Message = HttpContext.Session.GetString("Name");
        //    User obj = new User();
        //    var users = obj.GetAllUsers();
        //    return View(users);
        //}

        //public IActionResult Info()
        //{
        //    User obj = new User();
        //    obj.Id = 1;
        //    obj.Name = "zoya";
        //    ViewData["user"] = obj;
        //    return View("Login",obj);
        //}

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return Redirect("~/Login/Index");
        }

    }
}