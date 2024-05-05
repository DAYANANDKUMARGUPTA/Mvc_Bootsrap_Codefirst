namespace Mvc_Bootsrap_Codefirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblusers",
                c => new
                    {
                        uid = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        age = c.Int(nullable: false),
                        salary = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.uid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblusers");
        }
    }
}
