namespace Voting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Key = c.Int(nullable: false),
                        Value = c.String(),
                        Question_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.Question_Id)
                .Index(t => t.Question_Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Text = c.String(),
                        State = c.Int(nullable: false),
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Option = c.Int(nullable: false),
                        Question_Id = c.Guid(),
                        Voter_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.Question_Id)
                .ForeignKey("dbo.Users", t => t.Voter_Id)
                .Index(t => t.Question_Id)
                .Index(t => t.Voter_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votes", "Voter_Id", "dbo.Users");
            DropForeignKey("dbo.Votes", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.Options", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.Questions", "Asker_Id", "dbo.Users");
            DropIndex("dbo.Votes", new[] { "Voter_Id" });
            DropIndex("dbo.Votes", new[] { "Question_Id" });
            DropIndex("dbo.Options", new[] { "Question_Id" });
            DropIndex("dbo.Questions", new[] { "Asker_Id" });
            DropTable("dbo.Votes");
            DropTable("dbo.Users");
            DropTable("dbo.Questions");
            DropTable("dbo.Options");
        }
    }
}
