using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using DevOps.Hackathon.Web.Data;
using System.Data.Entity;
using DevOps.Hackathon.Web.Models;

namespace DevOps.Hackathon.Web.Migrations
{
    /// <summary>
    ///     This DB initalizer should only be used until the first version of the schema is stable.
    ///     It will delete the entire DB, and then seed it with some data.  
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DevelopmentModeInitializer<T> : DropCreateDatabaseAlways<BierDb>
    {
        public override void InitializeDatabase(BierDb context)
        {
            // THIS DOES NOT WORK ON AZURE! (SINGLE_USER is not allowed)
            //context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
            //    , string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database));

            base.InitializeDatabase(context);
            context.Dispose();
        }

        protected override void Seed(BierDb context)
        {

            var products = new List<Bier>()
            {
                    new DevOps.Hackathon.Web.Models.Bier() { Name ="Tuborg"},
                    new DevOps.Hackathon.Web.Models.Bier() { Name ="Carlsberg"},            
            };

            context.Biers.RemoveRange(context.Biers);
            context.Biers.AddRange(products);

                       //var customer = new List<Customer>()
            //{

            //    new Customer() { Name = "Hikmet", LastName = "Tuncer", Road = "Wegeners Vej", HouseNumber = "48", PostNumber = "4300", City = "Holbæk", Cell = "30532544"}
            //};
            //context.Customers.RemoveRange(context.Customers);
            //context.Customers.AddRange(customer);

            base.Seed(context);

        }

    }
}