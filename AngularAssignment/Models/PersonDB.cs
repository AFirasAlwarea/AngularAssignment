using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AngularAssignment.Models
{
    public class PersonDB : DbContext
    {
        public DbSet<Person> Persons { get; set; }
    }
}