namespace Proiect_IAME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_DurateServicii : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DurateServicii",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Serviciu = c.Int(nullable: false),
                        Ore = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DurateServicii");
        }
    }
}
