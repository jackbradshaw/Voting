namespace Voting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Votes", "QuestionId", "dbo.Questions");
            DropIndex("dbo.Votes", new[] { "QuestionId" });
            AddColumn("dbo.Votes", "OptionId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Votes", "OptionId");
            AddForeignKey("dbo.Votes", "OptionId", "dbo.Options", "Id", cascadeDelete: true);
            DropColumn("dbo.Votes", "Option");
            DropColumn("dbo.Votes", "QuestionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Votes", "QuestionId", c => c.Guid(nullable: false));
            AddColumn("dbo.Votes", "Option", c => c.Int(nullable: false));
            DropForeignKey("dbo.Votes", "OptionId", "dbo.Options");
            DropIndex("dbo.Votes", new[] { "OptionId" });
            DropColumn("dbo.Votes", "OptionId");
            CreateIndex("dbo.Votes", "QuestionId");
            AddForeignKey("dbo.Votes", "QuestionId", "dbo.Questions", "Id", cascadeDelete: true);
        }
    }
}
