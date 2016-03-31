namespace ThingWall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserFriends", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserFriends", new[] { "User_Id" });
            DropTable("dbo.UserFriends");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserFriends",
                c => new
                    {
                        UserFriendID = c.Guid(nullable: false),
                        User1 = c.Guid(nullable: false),
                        User2 = c.Guid(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserFriendID);
            
            CreateIndex("dbo.UserFriends", "User_Id");
            AddForeignKey("dbo.UserFriends", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
