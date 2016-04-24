namespace ThingWall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userFix : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE dbo.AspNetUsers SET Nick = 'Anonymous' WHERE Nick IS NULL");
            AlterColumn("dbo.AspNetUsers", "Nick", c => c.String(nullable: false, defaultValueSql: "'Anonymous'"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Nick", c => c.String());
        }
    }
}
