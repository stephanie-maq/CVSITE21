namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSavedbyUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "SavedByUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Projects", "SavedByUserId");
            AddForeignKey("dbo.Projects", "SavedByUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "SavedByUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Projects", new[] { "SavedByUserId" });
            DropColumn("dbo.Projects", "SavedByUserId");
        }
    }
}
