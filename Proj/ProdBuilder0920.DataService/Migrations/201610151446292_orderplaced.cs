namespace ProdBuilder0920.DataService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderplaced : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderPlaced", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "OrderPlaced");
        }
    }
}
