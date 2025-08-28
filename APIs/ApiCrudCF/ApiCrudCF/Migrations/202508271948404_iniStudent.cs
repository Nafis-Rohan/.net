namespace ApiCrudCF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iniStudent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        SId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
