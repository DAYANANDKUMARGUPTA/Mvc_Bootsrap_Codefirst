namespace Mvc_Bootsrap_Codefirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblEmployees", "name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblEmployees", "name", c => c.Int(nullable: false));
        }
    }
}
