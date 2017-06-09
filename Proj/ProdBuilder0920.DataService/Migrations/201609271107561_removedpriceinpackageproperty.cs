namespace ProdBuilder0920.DataService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedpriceinpackageproperty : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Packages", "PackageFinalPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Packages", "PackageFinalPrice", c => c.Int(nullable: false));
        }
    }
}
