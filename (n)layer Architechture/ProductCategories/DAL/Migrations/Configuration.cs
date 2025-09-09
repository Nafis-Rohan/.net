namespace DAL.Migrations
{
    using DAL.EF.tables;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.UMSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF.UMSContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.


            //Random random = new Random();
            //for (int i = 0; i < 50; i++)
            //{
            //    var s = new Product()
            //    {
            //        Name = "Book" + i,
            //        CId = random.Next(1, 5),

            //    };
            //    context.Products.Add(s);
            //}
        }
    }
}
