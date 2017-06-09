namespace ProdBuilder0920.DataService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class parttypepropsaltered : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PartTypes", "Package_PackageId", "dbo.Packages");
            DropIndex("dbo.PartTypes", new[] { "Package_PackageId" });
            RenameColumn(table: "dbo.PartTypes", name: "Package_PackageId", newName: "PackageId");
            AlterColumn("dbo.PartTypes", "PackageId", c => c.Int(nullable: false));
            CreateIndex("dbo.PartTypes", "PackageId");
            AddForeignKey("dbo.PartTypes", "PackageId", "dbo.Packages", "PackageId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PartTypes", "PackageId", "dbo.Packages");
            DropIndex("dbo.PartTypes", new[] { "PackageId" });
            AlterColumn("dbo.PartTypes", "PackageId", c => c.Int());
            RenameColumn(table: "dbo.PartTypes", name: "PackageId", newName: "Package_PackageId");
            CreateIndex("dbo.PartTypes", "Package_PackageId");
            AddForeignKey("dbo.PartTypes", "Package_PackageId", "dbo.Packages", "PackageId");
        }
    }
}
