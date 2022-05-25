namespace AliHaydarAtma.Entites.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseOlustur : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblKategori",
                c => new
                    {
                        KategoriId = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(maxLength: 100, unicode: false),
                        KategoriAciklama = c.String(maxLength: 500, unicode: false),
                        KategoriDurumu = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.KategoriId);
            
            CreateTable(
                "dbo.tblUrun",
                c => new
                    {
                        UrunId = c.Int(nullable: false, identity: true),
                        UrunAdi = c.String(maxLength: 100, unicode: false),
                        UrunKodu = c.Int(nullable: false),
                        UrunFiyat = c.Int(nullable: false),
                        UrunStok = c.Int(nullable: false),
                        KategoriId = c.Int(nullable: false),
                        Musteri_MusteriId = c.Int(),
                    })
                .PrimaryKey(t => t.UrunId)
                .ForeignKey("dbo.tblKategori", t => t.KategoriId, cascadeDelete: true)
                .ForeignKey("dbo.tblMusteri", t => t.Musteri_MusteriId)
                .Index(t => t.KategoriId)
                .Index(t => t.Musteri_MusteriId);
            
            CreateTable(
                "dbo.tblSepet",
                c => new
                    {
                        SepetId = c.Int(nullable: false, identity: true),
                        SepetAdet = c.Int(nullable: false),
                        SepetToplam = c.Int(nullable: false),
                        MusteriId = c.Int(nullable: false),
                        UrunId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SepetId)
                .ForeignKey("dbo.tblMusteri", t => t.MusteriId, cascadeDelete: true)
                .ForeignKey("dbo.tblUrun", t => t.UrunId, cascadeDelete: true)
                .Index(t => t.MusteriId)
                .Index(t => t.UrunId);
            
            CreateTable(
                "dbo.tblMusteri",
                c => new
                    {
                        MusteriId = c.Int(nullable: false, identity: true),
                        MusteriAdi = c.String(maxLength: 100, unicode: false),
                        MusteriSoyadi = c.String(maxLength: 100, unicode: false),
                        DogumTarihi = c.DateTime(nullable: false, storeType: "date"),
                        Musteri_MusteriId = c.Int(),
                    })
                .PrimaryKey(t => t.MusteriId)
                .ForeignKey("dbo.tblMusteri", t => t.Musteri_MusteriId)
                .Index(t => t.Musteri_MusteriId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblSepet", "UrunId", "dbo.tblUrun");
            DropForeignKey("dbo.tblSepet", "MusteriId", "dbo.tblMusteri");
            DropForeignKey("dbo.tblUrun", "Musteri_MusteriId", "dbo.tblMusteri");
            DropForeignKey("dbo.tblMusteri", "Musteri_MusteriId", "dbo.tblMusteri");
            DropForeignKey("dbo.tblUrun", "KategoriId", "dbo.tblKategori");
            DropIndex("dbo.tblMusteri", new[] { "Musteri_MusteriId" });
            DropIndex("dbo.tblSepet", new[] { "UrunId" });
            DropIndex("dbo.tblSepet", new[] { "MusteriId" });
            DropIndex("dbo.tblUrun", new[] { "Musteri_MusteriId" });
            DropIndex("dbo.tblUrun", new[] { "KategoriId" });
            DropTable("dbo.tblMusteri");
            DropTable("dbo.tblSepet");
            DropTable("dbo.tblUrun");
            DropTable("dbo.tblKategori");
        }
    }
}
