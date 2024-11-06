namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig15 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Profiles", "Name");
            DropColumn("dbo.Profiles", "Profession");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profiles", "Profession", c => c.String());
            AddColumn("dbo.Profiles", "Name", c => c.String());
        }
    }
}
