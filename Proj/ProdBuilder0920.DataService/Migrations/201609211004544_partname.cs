namespace ProdBuilder0920.DataService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class partname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parts", "PartName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parts", "PartName");
        }
    }
}
