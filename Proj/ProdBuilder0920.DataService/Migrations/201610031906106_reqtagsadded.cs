namespace ProdBuilder0920.DataService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reqtagsadded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Packages", "PackageName", c => c.String(nullable: false));
            AlterColumn("dbo.Packages", "PackageDescription", c => c.String(nullable: false));
            AlterColumn("dbo.Packages", "PackageProductionCode", c => c.String(nullable: false));
            AlterColumn("dbo.PartTypes", "PartTypeName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PartTypes", "PartTypeName", c => c.String());
            AlterColumn("dbo.Packages", "PackageProductionCode", c => c.String());
            AlterColumn("dbo.Packages", "PackageDescription", c => c.String());
            AlterColumn("dbo.Packages", "PackageName", c => c.String());
        }
    }
}
