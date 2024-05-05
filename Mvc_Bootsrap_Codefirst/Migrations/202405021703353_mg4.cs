namespace Mvc_Bootsrap_Codefirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblusers", "country", c => c.Int(nullable: false));
            AddColumn("dbo.tblusers", "state", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblusers", "state");
            DropColumn("dbo.tblusers", "country");
        }
    }
}
