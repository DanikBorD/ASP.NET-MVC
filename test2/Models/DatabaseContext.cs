using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using test2.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace test2.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}