namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "IsRead", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "IsRead");
        }
    }
}
