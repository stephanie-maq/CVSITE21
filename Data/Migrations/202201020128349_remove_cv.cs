namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_cv : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.CVs");
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
            
        }
    }
}
