namespace CofffeOrderApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addOrderStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderInfoes", "ORDER_STATUS", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderInfoes", "ORDER_STATUS");
        }
    }
}
