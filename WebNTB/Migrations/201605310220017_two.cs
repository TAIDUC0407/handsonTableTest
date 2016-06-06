namespace WebNTB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class two : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BangTheoDoiToCats", "SLKeHoach", c => c.Int(nullable: false));
            AlterColumn("dbo.BangTheoDoiToCats", "ThucHien", c => c.Int(nullable: false));
            AlterColumn("dbo.BangTheoDoiToCats", "LuyKeThucHien", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BangTheoDoiToCats", "LuyKeThucHien", c => c.String());
            AlterColumn("dbo.BangTheoDoiToCats", "ThucHien", c => c.String());
            AlterColumn("dbo.BangTheoDoiToCats", "SLKeHoach", c => c.String());
        }
    }
}
