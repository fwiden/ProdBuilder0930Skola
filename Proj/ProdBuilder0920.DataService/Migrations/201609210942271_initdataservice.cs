namespace ProdBuilder0920.DataService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdataservice : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderNr = c.String(),
                        OrderlSum = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        OrderStatus = c.Int(),
                        CustomerId = c.Int(nullable: false),
                        PackageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Packages", t => t.PackageId, cascadeDelete: true)
                .Index(t => t.PackageId);
            
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        PackageId = c.Int(nullable: false, identity: true),
                        PackageName = c.String(),
                        PackageDescription = c.String(),
                        PackageStartPrice = c.Int(nullable: false),
                        PackageProductionCode = c.String(),
                        ImageUrl = c.String(),
                        PartTypeId = c.Int(nullable: false),
                        PackageSeriesId = c.Int(nullable: false),
                        PackageSeries_PackageSeriesId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PackageId)
                .ForeignKey("dbo.PackageSeries", t => t.PackageSeries_PackageSeriesId, cascadeDelete: true)
                .Index(t => t.PackageSeries_PackageSeriesId);
            
            CreateTable(
                "dbo.PackageSeries",
                c => new
                    {
                        PackageSeriesId = c.String(nullable: false, maxLength: 128),
                        PackageSeriesName = c.String(),
                    })
                .PrimaryKey(t => t.PackageSeriesId);
            
            CreateTable(
                "dbo.PartTypes",
                c => new
                    {
                        PartTypeId = c.Int(nullable: false, identity: true),
                        PartTypeName = c.String(nullable: false),
                        PackageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PartTypeId)
                .ForeignKey("dbo.Packages", t => t.PackageId, cascadeDelete: true)
                .Index(t => t.PackageId);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        PartId = c.Int(nullable: false, identity: true),
                        PartTypeId = c.Int(nullable: false),
                        PartProductionCode = c.String(nullable: false),
                        PartDescription = c.String(nullable: false, maxLength: 100),
                        PartPrice = c.Int(nullable: false),
                        PartDeliverytime = c.DateTime(nullable: false),
                        PartImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.PartId)
                .ForeignKey("dbo.PartTypes", t => t.PartTypeId, cascadeDelete: true)
                .Index(t => t.PartTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parts", "PartTypeId", "dbo.PartTypes");
            DropForeignKey("dbo.Orders", "PackageId", "dbo.Packages");
            DropForeignKey("dbo.PartTypes", "PackageId", "dbo.Packages");
            DropForeignKey("dbo.Packages", "PackageSeries_PackageSeriesId", "dbo.PackageSeries");
            DropIndex("dbo.Parts", new[] { "PartTypeId" });
            DropIndex("dbo.PartTypes", new[] { "PackageId" });
            DropIndex("dbo.Packages", new[] { "PackageSeries_PackageSeriesId" });
            DropIndex("dbo.Orders", new[] { "PackageId" });
            DropTable("dbo.Parts");
            DropTable("dbo.PartTypes");
            DropTable("dbo.PackageSeries");
            DropTable("dbo.Packages");
            DropTable("dbo.Orders");
        }
    }
}
