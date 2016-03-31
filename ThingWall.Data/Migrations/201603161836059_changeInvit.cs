namespace ThingWall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeInvit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FriendInvitations", "Recipient", c => c.String(nullable: false));
            AlterColumn("dbo.FriendInvitations", "Sender", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FriendInvitations", "Sender", c => c.Guid(nullable: false));
            AlterColumn("dbo.FriendInvitations", "Recipient", c => c.Guid(nullable: false));
        }
    }
}
