namespace ProdBuilder0920.DataService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class packetseriesid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Packages", "PackageSeries_PackageSeriesId", "dbo.PackageSeries");
            DropIndex("dbo.Packages", new[] { "PackageSeries_PackageSeriesId" });
            DropColumn("dbo.Packages", "PackageSeriesId");
            RenameColumn(table: "dbo.Packages", name: "PackageSeries_PackageSeriesId", newName: "PackageSeriesId");
            DropPrimaryKey("dbo.PackageSeries");
            AlterColumn("dbo.Packages", "PackageSeriesId", c => c.Int(nullable: false));
            AlterColumn("dbo.PackageSeries", "PackageSeriesId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.PackageSeries", "PackageSeriesId");
            CreateIndex("dbo.Packages", "PackageSeriesId");
            AddForeignKey("dbo.Packages", "PackageSeriesId", "dbo.PackageSeries", "PackageSeriesId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Packages", "PackageSeriesId", "dbo.PackageSeries");
            DropIndex("dbo.Packages", new[] { "PackageSeriesId" });
            DropPrimaryKey("dbo.PackageSeries");
            AlterColumn("dbo.PackageSeries", "PackageSeriesId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Packages", "PackageSeriesId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.PackageSeries", "PackageSeriesId");
            RenameColumn(table: "dbo.Packages", name: "PackageSeriesId", newName: "PackageSeries_PackageSeriesId");
            AddColumn("dbo.Packages", "PackageSeriesId", c => c.Int(nullable: false));
            CreateIndex("dbo.Packages", "PackageSeries_PackageSeriesId");
            AddForeignKey("dbo.Packages", "PackageSeries_PackageSeriesId", "dbo.PackageSeries", "PackageSeriesId");
        }
    }
}
