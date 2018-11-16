using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FisrtAspMVC.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StudentCode { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
