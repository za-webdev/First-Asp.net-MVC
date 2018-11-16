using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FisrtAspMVC.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int IsSuperAdmin { get; set; }


    }
    
}
