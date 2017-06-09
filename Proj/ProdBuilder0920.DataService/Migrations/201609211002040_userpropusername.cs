namespace ProdBuilder0920.DataService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userpropusername : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Username", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Username");
        }
    }
}
