namespace ThingWall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChngeUserData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserFriends",
                c => new
                    {
                        UserFriendID = c.Guid(nullable: false),
                        User1 = c.String(nullable: false),
                        User2 = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserFriendID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserFriends");
        }
    }
}
