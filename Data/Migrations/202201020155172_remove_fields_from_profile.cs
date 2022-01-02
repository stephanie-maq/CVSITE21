namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class remove_fields_from_profile : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Profiles", "Experience");
            DropColumn("dbo.Profiles", "Education");
            DropColumn("dbo.Profiles", "Skills");
        }

        public override void Down()
        {
        }
    }
}
