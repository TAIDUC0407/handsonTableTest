namespace WebNTB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BangTenMatHangs",
                c => new
                    {
                        MaHang = c.String(nullable: false, maxLength: 50),
                        TenHang = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaHang);
            
            CreateTable(
                "dbo.BangTheoDoiToCats",
                c => new
                    {
                        MaChuyen = c.Int(nullable: false, identity: true),
                        MaHang = c.String(maxLength: 50),
                        SLKeHoach = c.String(),
                        ThucHien = c.String(),
                        LuyKeThucHien = c.String(),
                        DenBaoCapBTP = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaChuyen)
                .ForeignKey("dbo.BangTenMatHangs", t => t.MaHang)
                .Index(t => t.MaHang);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BangTheoDoiToCats", "MaHang", "dbo.BangTenMatHangs");
            DropIndex("dbo.BangTheoDoiToCats", new[] { "MaHang" });
            DropTable("dbo.BangTheoDoiToCats");
            DropTable("dbo.BangTenMatHangs");
        }
    }
}
