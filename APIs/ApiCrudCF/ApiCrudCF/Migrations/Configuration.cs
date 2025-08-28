namespace ApiCrudCF.Migrations
{
    using ApiCrudCF.EF.Tables;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApiCrudCF.EF.UMContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApiCrudCF.EF.UMContext context)
        {

            Random random = new Random();
            for (int i = 0; i < 50; i++)
            {
                var s = new Student()
                {
                    Name = "Student" + i,
                    DeptId = random.Next(1, 7),
                    Cgpa = 0.0f

                };
                context.Students.Add(s);
            }

            
            for (int i = 0; i < 50; i++)
            {
                var s = new Student()
                {
                    Name = Guid.NewGuid().ToString().Substring(0, 11),
                    DeptId = random.Next(1, 7),
                    Cgpa = 0.0f

                };
                context.Students.Add(s);
            }
            context.SaveChanges();


            //string[] deptNames = { "CSE", "EEE", "BBA", "Civil", "Mechanical", "Architecture" };

            //foreach (var i in deptNames)
            //{
            //    var d = new Department()
            //    {
            //        Name = i,
            //    };
            //    context.Departments.Add(d);
            //}

            //context.SaveChanges();



            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
