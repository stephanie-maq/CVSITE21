namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedSomeClasses : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Skills", "Email", "dbo.Profiles");
            DropForeignKey("dbo.WorkExperiences", "Email", "dbo.Profiles");
            DropForeignKey("dbo.AcademicExperiences", "Email", "dbo.Profiles");
            DropIndex("dbo.AcademicExperiences", new[] { "Email" });
            DropIndex("dbo.Skills", new[] { "Email" });
            DropIndex("dbo.WorkExperiences", new[] { "Email" });
            AddColumn("dbo.Profiles", "AcademicExperiences", c => c.String());
            AddColumn("dbo.Profiles", "Skills", c => c.String());
            AddColumn("dbo.Profiles", "WorkExperiences", c => c.String());
            DropTable("dbo.AcademicExperiences");
            DropTable("dbo.Skills");
            DropTable("dbo.WorkExperiences");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WorkExperiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 128),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 128),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AcademicExperiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 128),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Profiles", "WorkExperiences");
            DropColumn("dbo.Profiles", "Skills");
            DropColumn("dbo.Profiles", "AcademicExperiences");
            CreateIndex("dbo.WorkExperiences", "Email");
            CreateIndex("dbo.Skills", "Email");
            CreateIndex("dbo.AcademicExperiences", "Email");
            AddForeignKey("dbo.AcademicExperiences", "Email", "dbo.Profiles", "Email");
            AddForeignKey("dbo.WorkExperiences", "Email", "dbo.Profiles", "Email");
            AddForeignKey("dbo.Skills", "Email", "dbo.Profiles", "Email");
        }
    }
}
