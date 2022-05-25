namespace AliHaydarAtma.Entites.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabloDuzelt2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblSepet", "SepetDurumu", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblSepet", "SepetDurumu");
        }
    }
}
