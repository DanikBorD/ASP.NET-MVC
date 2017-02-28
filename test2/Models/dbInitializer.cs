using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace test2.Models
{
    public class dbInitializer : DropCreateDatabaseAlways<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {

            var companies = new List<Company>
            {
                new Company {Name = "Company 1"},
                new Company {Name = "Company 2"}

            };

            companies.ForEach(p => context.Companies.Add(p));
            context.SaveChanges();


            var persons = new List<Person>
            {
                 new Person {FirstName = "FirstName 1", LastName = "LastName 1", MiddleName = "MiddleName 1", Telephone = "111", CompanyId = 1},
                 new Person {FirstName = "FirstName 2", LastName = "LastName 2", MiddleName = "MiddleName 2", Telephone = "222", CompanyId = 1},
                 new Person {FirstName = "FirstName 3", LastName = "LastName 3", MiddleName = "MiddleName 3", Telephone = "333", CompanyId = 1},
                 new Person {FirstName = "FirstName 4", LastName = "LastName 4", MiddleName = "MiddleName 4", Telephone = "444", CompanyId = 2},
                 new Person {FirstName = "FirstName 5", LastName = "LastName 5", MiddleName = "MiddleName 5", Telephone = "555", CompanyId = 2}
            };
            
            persons.ForEach(p => context.Persons.Add(p));
            context.SaveChanges();         



        }
    }
}