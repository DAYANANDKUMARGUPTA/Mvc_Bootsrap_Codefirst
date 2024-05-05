namespace Mvc_Bootsrap_Codefirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblcountries",
                c => new
                    {
                        cid = c.Int(nullable: false, identity: true),
                        cname = c.String(),
                    })
                .PrimaryKey(t => t.cid);
            
            CreateTable(
                "dbo.tblEmployees",
                c => new
                    {
                        empid = c.Int(nullable: false, identity: true),
                        name = c.Int(nullable: false),
                        age = c.Int(nullable: false),
                        country = c.Int(nullable: false),
                        state = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.empid);
            
            CreateTable(
                "dbo.tblstates",
                c => new
                    {
                        sid = c.Int(nullable: false, identity: true),
                        cid = c.Int(nullable: false),
                        sname = c.String(),
                    })
                .PrimaryKey(t => t.sid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblstates");
            DropTable("dbo.tblEmployees");
            DropTable("dbo.tblcountries");
        }
    }
}
