namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class message_validation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "Text", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "Text", c => c.String());
        }
    }
}
