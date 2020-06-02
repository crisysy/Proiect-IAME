namespace Proiect_IAME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_NumeContact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Programari", "Nume", c => c.String());
            AddColumn("dbo.Programari", "Contact", c => c.String());
            AddColumn("dbo.AspNetUsers", "Nume", c => c.String());
            AddColumn("dbo.AspNetUsers", "Contact", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Contact");
            DropColumn("dbo.AspNetUsers", "Nume");
            DropColumn("dbo.Programari", "Contact");
            DropColumn("dbo.Programari", "Nume");
        }
    }
}
