namespace CofffeOrderApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateOrderInfoTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderInfoes", "DRINK_AMOUNT", c => c.Int(nullable: false));
            DropColumn("dbo.OrderInfoes", "DRINK_SHOT");
            DropColumn("dbo.OrderInfoes", "DRINK_MILK");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderInfoes", "DRINK_MILK", c => c.String());
            AddColumn("dbo.OrderInfoes", "DRINK_SHOT", c => c.String());
            DropColumn("dbo.OrderInfoes", "DRINK_AMOUNT");
        }
    }
}
