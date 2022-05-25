namespace AliHaydarAtma.Entites.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabloDuzelt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblUrun", "UrunDurumu", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblUrun", "UrunDurumu");
        }
    }
}
