using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mvc_Bootsrap_Codefirst.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("abc")
        {

        }
        public DbSet<tblEmployee> tblEmployees { get; set; }
        public DbSet<tbluser>tblusers  { get; set; }
        public DbSet<tblcountry> tblcountries { get; set; }
        public DbSet<tblstate> tblstates { get; set; }

    }
}