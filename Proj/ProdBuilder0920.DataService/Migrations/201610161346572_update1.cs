namespace ProdBuilder0920.DataService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApViewModels",
                c => new
                    {
                        PartId = c.Int(nullable: false, identity: true),
                        PartManufacturer = c.String(nullable: false),
                        PartModelName = c.String(nullable: false),
                        PartTypeId = c.Int(nullable: false),
                        PartProductionCode = c.String(nullable: false),
                        PartDescription = c.String(nullable: false, maxLength: 255),
                        PartPrice = c.Int(nullable: false),
                        PartDeliverytime = c.DateTime(nullable: false),
                        PartImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.PartId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ApViewModels");
        }
    }
}
