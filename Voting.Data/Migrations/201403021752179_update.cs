namespace Voting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Votes", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Votes", "Id", c => c.Guid(nullable: false));
        }
    }
}
