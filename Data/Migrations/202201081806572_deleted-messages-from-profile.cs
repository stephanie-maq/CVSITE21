namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedmessagesfromprofile : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "Profile_UserId", "dbo.Profiles");
            DropIndex("dbo.Messages", new[] { "Profile_UserId" });
            DropColumn("dbo.Messages", "Profile_UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "Profile_UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Messages", "Profile_UserId");
            AddForeignKey("dbo.Messages", "Profile_UserId", "dbo.Profiles", "UserId");
        }
    }
}
