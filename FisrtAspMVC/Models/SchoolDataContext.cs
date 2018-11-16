using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FisrtAspMVC.Models
{
    public class SchoolDataContext:DbContext
    {
        public SchoolDataContext(DbContextOptions options)
            :base (options)
        { }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Student> Student { get; set; }

        public DbSet<DbAccess> DbAccess { get; set; }

    }
}
