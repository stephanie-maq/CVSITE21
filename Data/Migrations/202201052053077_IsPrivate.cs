﻿namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsPrivate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "IsPrivate", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Profiles", "IsPrivate");
        }
    }
}
