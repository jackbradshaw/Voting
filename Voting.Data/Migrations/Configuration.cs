namespace Voting.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Voting.Domain.QuestionAggregate;
    using Voting.Domain.UserAggregate;

    internal sealed class Configuration : DbMigrationsConfiguration<Voting.Data.VotingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Voting.Data.VotingContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            //User jack = new User("Jack");

            //context.Users.AddOrUpdate(jack);
            //context.Questions.AddOrUpdate(
            //    new Question("How are you?", 
            //        new List<string>(){"Good", "Fine","Bad"},
            //        jack
            //    ));

            //context.SaveChanges();
            
           
        }
    }
}
