namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditProfile : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "Email", "dbo.Profiles");
            DropPrimaryKey("dbo.Profiles");
            AddColumn("dbo.Profiles", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Profiles", "Email", c => c.String());
            AddPrimaryKey("dbo.Profiles", "UserId");
            AddForeignKey("dbo.Projects", "Email", "dbo.Profiles", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "Email", "dbo.Profiles");
            DropPrimaryKey("dbo.Profiles");
            AlterColumn("dbo.Profiles", "Email", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Profiles", "UserId");
            AddPrimaryKey("dbo.Profiles", "Email");
            AddForeignKey("dbo.Projects", "Email", "dbo.Profiles", "Email");
        }
    }
}
