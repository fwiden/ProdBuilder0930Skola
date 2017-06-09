namespace ProdBuilder0920.DataService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class urlimagerequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Packages", "PackageImageUrl", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Packages", "PackageImageUrl", c => c.String());
        }
    }
}
