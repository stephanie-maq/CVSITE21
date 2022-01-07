namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class changeinmessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Read", c => c.Boolean(nullable: false));
            DropColumn("dbo.Messages", "isRead");
        }

        public override void Down()
        {
            AddColumn("dbo.Messages", "isRead", c => c.Boolean(nullable: false));
            DropColumn("dbo.Messages", "Read");
        }
    }
}
