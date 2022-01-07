namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmessageclass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sender = c.String(),
                        Text = c.String(),
                        Recipient = c.String(),
                        isRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Messages");
        }
    }
}
