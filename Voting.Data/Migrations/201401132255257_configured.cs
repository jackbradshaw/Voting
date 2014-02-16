namespace Voting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class configured : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "Asker_Id", "dbo.Users");
            DropForeignKey("dbo.Options", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.Votes", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.Votes", "Voter_Id", "dbo.Users");
            DropIndex("dbo.Questions", new[] { "Asker_Id" });
            DropIndex("dbo.Options", new[] { "Question_Id" });
            DropIndex("dbo.Votes", new[] { "Question_Id" });
            DropIndex("dbo.Votes", new[] { "Voter_Id" });
            RenameColumn(table: "dbo.Questions", name: "Asker_Id", newName: "AskerId");
            RenameColumn(table: "dbo.Options", name: "Question_Id", newName: "QuestionId");
            RenameColumn(table: "dbo.Votes", name: "Question_Id", newName: "QuestionId");
            RenameColumn(table: "dbo.Votes", name: "Voter_Id", newName: "VoterId");
            AddColumn("dbo.Users", "Name", c => c.String());
            AlterColumn("dbo.Options", "QuestionId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Questions", "AskerId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Votes", "QuestionId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Votes", "VoterId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Questions", "AskerId");
            CreateIndex("dbo.Options", "QuestionId");
            CreateIndex("dbo.Votes", "QuestionId");
            CreateIndex("dbo.Votes", "VoterId");
            AddForeignKey("dbo.Questions", "AskerId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Options", "QuestionId", "dbo.Questions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Votes", "QuestionId", "dbo.Questions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Votes", "VoterId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votes", "VoterId", "dbo.Users");
            DropForeignKey("dbo.Votes", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Options", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "AskerId", "dbo.Users");
            DropIndex("dbo.Votes", new[] { "VoterId" });
            DropIndex("dbo.Votes", new[] { "QuestionId" });
            DropIndex("dbo.Options", new[] { "QuestionId" });
            DropIndex("dbo.Questions", new[] { "AskerId" });
            AlterColumn("dbo.Votes", "VoterId", c => c.Guid());
            AlterColumn("dbo.Votes", "QuestionId", c => c.Guid());
            AlterColumn("dbo.Questions", "AskerId", c => c.Guid());
            AlterColumn("dbo.Options", "QuestionId", c => c.Guid());
            DropColumn("dbo.Users", "Name");
            RenameColumn(table: "dbo.Votes", name: "VoterId", newName: "Voter_Id");
            RenameColumn(table: "dbo.Votes", name: "QuestionId", newName: "Question_Id");
            RenameColumn(table: "dbo.Options", name: "QuestionId", newName: "Question_Id");
            RenameColumn(table: "dbo.Questions", name: "AskerId", newName: "Asker_Id");
            CreateIndex("dbo.Votes", "Voter_Id");
            CreateIndex("dbo.Votes", "Question_Id");
            CreateIndex("dbo.Options", "Question_Id");
            CreateIndex("dbo.Questions", "Asker_Id");
            AddForeignKey("dbo.Votes", "Voter_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Votes", "Question_Id", "dbo.Questions", "Id");
            AddForeignKey("dbo.Options", "Question_Id", "dbo.Questions", "Id");
            AddForeignKey("dbo.Questions", "Asker_Id", "dbo.Users", "Id");
        }
    }
}
