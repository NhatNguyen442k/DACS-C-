using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using WebDACS.Models;

namespace WebDACS.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<WebDACS.Models.AppDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AppDataContext context)
        {
            base.Seed(context);
        }
    }
}