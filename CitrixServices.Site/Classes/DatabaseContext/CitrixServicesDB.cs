using CitrixServices.Site.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CitrixServices.Site.Classes.DatabaseContext
{
    public class CitrixServicesDB : DbContext
    {
        public DbSet<Token> Tokens { get; set; }
        public DbSet<User> Users { get; set; }
        public CitrixServicesDB() : base("CitrixServices")
        {
        }
    }
}