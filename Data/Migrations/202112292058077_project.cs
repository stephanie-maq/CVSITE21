﻿namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class project : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Projects",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Projects");
        }
    }
}
