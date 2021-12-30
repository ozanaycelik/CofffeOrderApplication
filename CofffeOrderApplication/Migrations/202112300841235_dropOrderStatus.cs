namespace CofffeOrderApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropOrderStatus : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OrderInfoes", "ORDER_STATUS");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderInfoes", "ORDER_STATUS", c => c.Boolean(nullable: false));
        }
    }
}
