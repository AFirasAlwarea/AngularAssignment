namespace AngularAssignment.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AngularAssignment.Models.PersonDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AngularAssignment.Models.PersonDB context)
        {
            context.Persons.AddOrUpdate(p => p.Email,
                new Person
                {
                    Name = "Firas",
                    Telephone = "0762620287",
                    Email = "firas.wira@gmail.com"
                },
                new Person
                {
                    Name = "Husam",
                    Telephone = "0933366698",
                    Email = "hjammal@gmail.com"
                },
                new Person
                {
                    Name = "Nima",
                    Telephone = "0766665555",
                    Email = "nima.azizi@gmail.com"
                },
                new Person
                {
                    Name = "Amer",
                    Telephone = "0944422215",
                    Email = "amer.jammal@gmail.com"
                });
        }
    }
}
