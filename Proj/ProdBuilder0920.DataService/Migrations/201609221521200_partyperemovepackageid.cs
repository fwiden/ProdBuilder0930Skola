namespace ProdBuilder0920.DataService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class partyperemovepackageid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PartTypes", "PackageId", "dbo.Packages");
            DropIndex("dbo.PartTypes", new[] { "PackageId" });
            RenameColumn(table: "dbo.PartTypes", name: "PackageId", newName: "Package_PackageId");
            AlterColumn("dbo.PartTypes", "Package_PackageId", c => c.Int());
            CreateIndex("dbo.PartTypes", "Package_PackageId");
            AddForeignKey("dbo.PartTypes", "Package_PackageId", "dbo.Packages", "PackageId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PartTypes", "Package_PackageId", "dbo.Packages");
            DropIndex("dbo.PartTypes", new[] { "Package_PackageId" });
            AlterColumn("dbo.PartTypes", "Package_PackageId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.PartTypes", name: "Package_PackageId", newName: "PackageId");
            CreateIndex("dbo.PartTypes", "PackageId");
            AddForeignKey("dbo.PartTypes", "PackageId", "dbo.Packages", "PackageId", cascadeDelete: true);
        }
    }
}
