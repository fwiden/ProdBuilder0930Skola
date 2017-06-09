namespace ProdBuilder0920.DataService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedentities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "UsernameCustomer", c => c.String(nullable: false));
            AddColumn("dbo.Packages", "PackageFinalPrice", c => c.Int(nullable: false));
            AddColumn("dbo.Packages", "PackageImageUrl", c => c.String());
            AddColumn("dbo.PartTypes", "PartTypeImageUrl", c => c.String());
            AlterColumn("dbo.PartTypes", "PartTypeName", c => c.String());
            DropColumn("dbo.Orders", "Username");
            DropColumn("dbo.Packages", "ImageUrl");
            DropColumn("dbo.Packages", "PartTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Packages", "PartTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Packages", "ImageUrl", c => c.String());
            AddColumn("dbo.Orders", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.PartTypes", "PartTypeName", c => c.String(nullable: false));
            DropColumn("dbo.PartTypes", "PartTypeImageUrl");
            DropColumn("dbo.Packages", "PackageImageUrl");
            DropColumn("dbo.Packages", "PackageFinalPrice");
            DropColumn("dbo.Orders", "UsernameCustomer");
        }
    }
}
