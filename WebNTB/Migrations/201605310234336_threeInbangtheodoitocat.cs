namespace WebNTB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class threeInbangtheodoitocat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BangTheoDoiToCats", "NgayTao", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BangTheoDoiToCats", "NgayTao");
        }
    }
}
