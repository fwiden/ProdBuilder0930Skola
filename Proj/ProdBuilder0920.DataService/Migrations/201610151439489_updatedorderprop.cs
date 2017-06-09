namespace ProdBuilder0920.DataService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedorderprop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderDeliveryDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Orders", "OrderDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Orders", "OrderDeliveryDate");
        }
    }
}
