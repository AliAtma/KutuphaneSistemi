namespace AliHaydarAtma.Entites.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deneme : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblMusteri", "Musteri_MusteriId", "dbo.tblMusteri");
            DropForeignKey("dbo.tblUrun", "Musteri_MusteriId", "dbo.tblMusteri");
            DropIndex("dbo.tblUrun", new[] { "Musteri_MusteriId" });
            DropIndex("dbo.tblMusteri", new[] { "Musteri_MusteriId" });
            CreateTable(
                "dbo.tblPersonel",
                c => new
                    {
                        PersonelId = c.Int(nullable: false, identity: true),
                        PersonelAdi = c.String(maxLength: 100, unicode: false),
                        PersonelSoyadi = c.String(maxLength: 100, unicode: false),
                        PersonelEmail = c.String(maxLength: 100, unicode: false),
                        PersonelParola = c.String(maxLength: 30, unicode: false),
                        PersonelDurumu = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PersonelId);
            
            AddColumn("dbo.tblUrun", "KategoriAdi", c => c.String());
            DropColumn("dbo.tblUrun", "Musteri_MusteriId");
            DropColumn("dbo.tblMusteri", "Musteri_MusteriId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblMusteri", "Musteri_MusteriId", c => c.Int());
            AddColumn("dbo.tblUrun", "Musteri_MusteriId", c => c.Int());
            DropColumn("dbo.tblUrun", "KategoriAdi");
            DropTable("dbo.tblPersonel");
            CreateIndex("dbo.tblMusteri", "Musteri_MusteriId");
            CreateIndex("dbo.tblUrun", "Musteri_MusteriId");
            AddForeignKey("dbo.tblUrun", "Musteri_MusteriId", "dbo.tblMusteri", "MusteriId");
            AddForeignKey("dbo.tblMusteri", "Musteri_MusteriId", "dbo.tblMusteri", "MusteriId");
        }
    }
}
