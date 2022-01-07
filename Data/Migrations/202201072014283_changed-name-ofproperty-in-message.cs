namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changednameofpropertyinmessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Receiver", c => c.String());
            DropColumn("dbo.Messages", "Recipient");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "Recipient", c => c.String());
            DropColumn("dbo.Messages", "Receiver");
        }
    }
}
