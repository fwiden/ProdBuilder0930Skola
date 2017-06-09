namespace ProdBuilder0920.DataService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Packages", "PackageSeriesId", "dbo.PackageSeries");
            DropPrimaryKey("dbo.PackageSeries");
            AlterColumn("dbo.PackageSeries", "PackageSeriesId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.PackageSeries", "PackageSeriesId");
            AddForeignKey("dbo.Packages", "PackageSeriesId", "dbo.PackageSeries", "PackageSeriesId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Packages", "PackageSeriesId", "dbo.PackageSeries");
            DropPrimaryKey("dbo.PackageSeries");
            AlterColumn("dbo.PackageSeries", "PackageSeriesId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.PackageSeries", "PackageSeriesId");
            AddForeignKey("dbo.Packages", "PackageSeriesId", "dbo.PackageSeries", "PackageSeriesId", cascadeDelete: true);
        }
    }
}
