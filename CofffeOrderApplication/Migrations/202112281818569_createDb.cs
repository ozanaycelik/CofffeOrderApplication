namespace CofffeOrderApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderInfoes",
                c => new
                    {
                        ORDER_REF = c.Int(nullable: false, identity: true),
                        CLIENT_INFO = c.String(),
                        CLIENT_PHONE = c.String(),
                        CLIENT_ADDRESS = c.String(),
                        DRINK_CODE = c.String(),
                        DRINK_HEIGHT = c.String(),
                        DRINK_SHOT = c.String(),
                        DRINK_MILK = c.String(),
                        ORDER_TOTAL = c.Double(nullable: false),
                        ORDER_DATE = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ORDER_REF);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OrderInfoes");
        }
    }
}
