namespace ApiCrudCF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedNameDatatype_CGPA_DeptId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Cgpa", c => c.Double());
            AddColumn("dbo.Students", "DeptId", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false, maxLength: 200, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Name", c => c.String());
            DropColumn("dbo.Students", "DeptId");
            DropColumn("dbo.Students", "Cgpa");
        }
    }
}
