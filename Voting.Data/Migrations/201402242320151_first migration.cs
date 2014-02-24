namespace Voting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Text = c.String(),
                        Asker_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Asker_Id)
                .Index(t => t.Asker_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Points = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Key = c.Int(nullable: false),
                        Value = c.String(),
                        Question_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.Question_Id, cascadeDelete: true)
                .Index(t => t.Question_Id);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        VoterId = c.Guid(nullable: false),
                        OptionId = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.VoterId, t.OptionId })
                .ForeignKey("dbo.Options", t => t.OptionId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.VoterId, cascadeDelete: true)
                .Index(t => t.OptionId)
                .Index(t => t.VoterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Options", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.Votes", "VoterId", "dbo.Users");
            DropForeignKey("dbo.Votes", "OptionId", "dbo.Options");
            DropForeignKey("dbo.Questions", "Asker_Id", "dbo.Users");
            DropIndex("dbo.Options", new[] { "Question_Id" });
            DropIndex("dbo.Votes", new[] { "VoterId" });
            DropIndex("dbo.Votes", new[] { "OptionId" });
            DropIndex("dbo.Questions", new[] { "Asker_Id" });
            DropTable("dbo.Votes");
            DropTable("dbo.Options");
            DropTable("dbo.Users");
            DropTable("dbo.Questions");
        }
    }
}
