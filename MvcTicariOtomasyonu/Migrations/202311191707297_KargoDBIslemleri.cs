namespace MvcTicariOtomasyonu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KargoDBIslemleri : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KargoDetays",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        aciklama = c.String(maxLength: 30, unicode: false),
                        takipKodu = c.String(maxLength: 10, unicode: false),
                        personel = c.String(maxLength: 20, unicode: false),
                        alici = c.String(maxLength: 25, unicode: false),
                        tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.KargoTakips",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        takipKodu = c.String(maxLength: 10, unicode: false),
                        aciklama = c.String(maxLength: 100, unicode: false),
                        tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.KargoTakips");
            DropTable("dbo.KargoDetays");
        }
    }
}
