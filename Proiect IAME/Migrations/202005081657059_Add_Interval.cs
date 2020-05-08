namespace Proiect_IAME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Interval : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Programari", "Interval", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Programari", "Interval");
        }
    }
}
