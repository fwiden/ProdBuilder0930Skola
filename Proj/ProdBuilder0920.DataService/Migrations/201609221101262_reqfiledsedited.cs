namespace ProdBuilder0920.DataService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reqfiledsedited : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Packages", "PackageSeries_PackageSeriesId", "dbo.PackageSeries");
            DropIndex("dbo.Packages", new[] { "PackageSeries_PackageSeriesId" });
            AlterColumn("dbo.Packages", "PackageSeries_PackageSeriesId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Packages", "PackageSeries_PackageSeriesId");
            AddForeignKey("dbo.Packages", "PackageSeries_PackageSeriesId", "dbo.PackageSeries", "PackageSeriesId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Packages", "PackageSeries_PackageSeriesId", "dbo.PackageSeries");
            DropIndex("dbo.Packages", new[] { "PackageSeries_PackageSeriesId" });
            AlterColumn("dbo.Packages", "PackageSeries_PackageSeriesId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Packages", "PackageSeries_PackageSeriesId");
            AddForeignKey("dbo.Packages", "PackageSeries_PackageSeriesId", "dbo.PackageSeries", "PackageSeriesId", cascadeDelete: true);
        }
    }
}
