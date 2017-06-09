namespace ProdBuilder0920.DataService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idpropertypackageseries2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PackageSeries", "PackageSeriesName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PackageSeries", "PackageSeriesName", c => c.String());
        }
    }
}
