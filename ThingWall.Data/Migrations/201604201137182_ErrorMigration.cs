namespace ThingWall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ErrorMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FriendInvitations",
                c => new
                    {
                        FriendInvitationID = c.Guid(nullable: false),
                        Recipient = c.String(nullable: false),
                        Sender = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FriendInvitationID);
            
            CreateTable(
                "dbo.UserFriends",
                c => new
                    {
                        UserFriendID = c.Guid(nullable: false),
                        User1 = c.String(nullable: false),
                        User2 = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserFriendID);
            
            AddColumn("dbo.Items", "AuthorID", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "AuthorID");
            DropTable("dbo.UserFriends");
            DropTable("dbo.FriendInvitations");
        }
    }
}
