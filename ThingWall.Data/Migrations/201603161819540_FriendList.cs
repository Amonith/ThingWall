namespace ThingWall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FriendList : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Friends", newName: "UserFriends");
            DropIndex("dbo.UserFriends", new[] { "user_Id" });
            DropPrimaryKey("dbo.UserFriends");
            CreateTable(
                "dbo.FriendInvitations",
                c => new
                    {
                        FriendInvitationID = c.Guid(nullable: false),
                        Recipient = c.Guid(nullable: false),
                        Sender = c.Guid(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FriendInvitationID);
            
            AddColumn("dbo.UserFriends", "UserFriendID", c => c.Guid(nullable: false));
            AddColumn("dbo.UserFriends", "User1", c => c.Guid(nullable: false));
            AddColumn("dbo.UserFriends", "User2", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.UserFriends", "UserFriendID");
            CreateIndex("dbo.UserFriends", "User_Id");
            DropColumn("dbo.UserFriends", "FrinedID");
            DropColumn("dbo.UserFriends", "TargetID");
            DropColumn("dbo.UserFriends", "Confim");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserFriends", "Confim", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserFriends", "TargetID", c => c.Guid(nullable: false));
            AddColumn("dbo.UserFriends", "FrinedID", c => c.Guid(nullable: false));
            DropIndex("dbo.UserFriends", new[] { "User_Id" });
            DropPrimaryKey("dbo.UserFriends");
            DropColumn("dbo.UserFriends", "User2");
            DropColumn("dbo.UserFriends", "User1");
            DropColumn("dbo.UserFriends", "UserFriendID");
            DropTable("dbo.FriendInvitations");
            AddPrimaryKey("dbo.UserFriends", "FrinedID");
            CreateIndex("dbo.UserFriends", "user_Id");
            RenameTable(name: "dbo.UserFriends", newName: "Friends");
        }
    }
}
