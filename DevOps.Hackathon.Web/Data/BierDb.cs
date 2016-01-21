using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DevOps.Hackathon.Web.Models; 


namespace DevOps.Hackathon.Web.Data
{
    public class BierDb : DbContext
    {
        public BierDb()
            : base("DefaultConnection")
        {
            // required to force Azure to run the migration scripts when deploying from Git
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<PizzaDb, Data.Migrations.Configuration>());

          //  Database.SetInitializer(new DevelopmentModeInitializer<PizzaDb>());
          //  Database.Initialize(false); // make the DB update directly instead of waiting for context usage            
        }

        public DbSet<Bier> Biers { get; set; }
        

    }
}