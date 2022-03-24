namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using Domain.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<Infrastructure.DAL.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Infrastructure.DAL.AppDbContext context)
        {
            var terminals = new List<Terminal>();
            terminals.Add(new Terminal { IP = "92.15.14.12", Status = "Waiting" });
            terminals.Add(new Terminal { IP = "92.15.14.13", Status = "Waiting" });
            terminals.Add(new Terminal { IP = "92.15.14.14", Status = "Waiting" });
            terminals.Add(new Terminal { IP = "92.15.14.15", Status = "Waiting" });
            terminals.Add(new Terminal { IP = "92.15.14.16", Status = "Waiting" });
            terminals.Add(new Terminal { IP = "192.15.141.12", Status = "Waiting" });
            terminals.Add(new Terminal { IP = "192.15.141.13", Status = "Waiting" });
            terminals.Add(new Terminal { IP = "192.15.141.14", Status = "Waiting" });
            terminals.Add(new Terminal { IP = "192.15.141.15", Status = "Waiting" });
            terminals.Add(new Terminal { IP = "192.15.141.16", Status = "Waiting" });

            context.Terminals.AddRange(terminals);
            base.Seed(context);
        }
    }
}
