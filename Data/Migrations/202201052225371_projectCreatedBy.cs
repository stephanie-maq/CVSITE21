namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projectCreatedBy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "CreatedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "CreatedBy");
        }
    }
}
