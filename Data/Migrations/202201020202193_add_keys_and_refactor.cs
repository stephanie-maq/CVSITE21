namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_keys_and_refactor : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Profiles");
            AddColumn("dbo.AcademicExperiences", "Email", c => c.String(maxLength: 128));
            AddColumn("dbo.Profiles", "Email", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Projects", "Email", c => c.String(maxLength: 128));
            AddColumn("dbo.Projects", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Skills", "Email", c => c.String(maxLength: 128));
            AddColumn("dbo.WorkExperiences", "Email", c => c.String(maxLength: 128));
            AlterColumn("dbo.AcademicExperiences", "Name", c => c.String());
            AlterColumn("dbo.Projects", "Title", c => c.String());
            AlterColumn("dbo.Projects", "Description", c => c.String());
            AlterColumn("dbo.Skills", "Name", c => c.String());
            AlterColumn("dbo.WorkExperiences", "Name", c => c.String());
            AddPrimaryKey("dbo.Profiles", "Email");
            CreateIndex("dbo.AcademicExperiences", "Email");
            CreateIndex("dbo.Projects", "Email");
            CreateIndex("dbo.Skills", "Email");
            CreateIndex("dbo.WorkExperiences", "Email");
            AddForeignKey("dbo.Projects", "Email", "dbo.Profiles", "Email");
            AddForeignKey("dbo.Skills", "Email", "dbo.Profiles", "Email");
            AddForeignKey("dbo.WorkExperiences", "Email", "dbo.Profiles", "Email");
            AddForeignKey("dbo.AcademicExperiences", "Email", "dbo.Profiles", "Email");
            DropColumn("dbo.Profiles", "Id");
            DropColumn("dbo.Profiles", "Languages");
            DropColumn("dbo.Projects", "Created");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CVs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(nullable: false),
                        LastEdited = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Projects", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.Profiles", "Languages", c => c.String());
            AddColumn("dbo.Profiles", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.AcademicExperiences", "Email", "dbo.Profiles");
            DropForeignKey("dbo.WorkExperiences", "Email", "dbo.Profiles");
            DropForeignKey("dbo.Skills", "Email", "dbo.Profiles");
            DropForeignKey("dbo.Projects", "Email", "dbo.Profiles");
            DropIndex("dbo.WorkExperiences", new[] { "Email" });
            DropIndex("dbo.Skills", new[] { "Email" });
            DropIndex("dbo.Projects", new[] { "Email" });
            DropIndex("dbo.AcademicExperiences", new[] { "Email" });
            DropPrimaryKey("dbo.Profiles");
            AlterColumn("dbo.WorkExperiences", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Skills", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.AcademicExperiences", "Name", c => c.String(nullable: false));
            DropColumn("dbo.WorkExperiences", "Email");
            DropColumn("dbo.Skills", "Email");
            DropColumn("dbo.Projects", "DateCreated");
            DropColumn("dbo.Projects", "Email");
            DropColumn("dbo.Profiles", "Email");
            DropColumn("dbo.AcademicExperiences", "Email");
            AddPrimaryKey("dbo.Profiles", "Id");
        }
    }
}
