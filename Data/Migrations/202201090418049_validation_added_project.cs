namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validation_added_project : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "Title", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Projects", "Description", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "Title", c => c.String(nullable: false));
        }
    }
}
