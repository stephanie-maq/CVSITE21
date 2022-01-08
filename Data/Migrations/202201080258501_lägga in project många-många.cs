namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class läggainprojectmångamånga : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProfileInProjects",
                c => new
                    {
                        ProfileId = c.String(nullable: false, maxLength: 128),
                        ProjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProfileId, t.ProjectID })
                .ForeignKey("dbo.Profiles", t => t.ProfileId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ProfileId)
                .Index(t => t.ProjectID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProfileInProjects", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.ProfileInProjects", "ProfileId", "dbo.Profiles");
            DropIndex("dbo.ProfileInProjects", new[] { "ProjectID" });
            DropIndex("dbo.ProfileInProjects", new[] { "ProfileId" });
            DropTable("dbo.ProfileInProjects");
        }
    }
}
