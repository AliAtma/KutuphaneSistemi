namespace AliHaydarAtma.Entites.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabloEkle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblMusteri", "MusteriDurumu", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblMusteri", "MusteriDurumu");
        }
    }
}
