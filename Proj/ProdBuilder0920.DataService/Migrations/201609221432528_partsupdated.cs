namespace ProdBuilder0920.DataService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class partsupdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parts", "PartManufacturer", c => c.String(nullable: false));
            AddColumn("dbo.Parts", "PartModelName", c => c.String(nullable: false));
            DropColumn("dbo.Parts", "PartName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Parts", "PartName", c => c.String(nullable: false));
            DropColumn("dbo.Parts", "PartModelName");
            DropColumn("dbo.Parts", "PartManufacturer");
        }
    }
}
