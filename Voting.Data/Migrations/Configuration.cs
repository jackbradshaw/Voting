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

            context.Users.AddOrUpdate(u => u.Name, new User("Jack"));
            context.Users.AddOrUpdate(u => u.Name, new User("Bob"));
            context.Users.AddOrUpdate(u => u.Name, new User("Fred"));

            //Add some users            
            for (int i = 0; i < 100; i++)
            {
                context.Users.AddOrUpdate(u => u.Name, new User(String.Format("User_{0}",i.ToString())));
            }

          

            //Add some questions
            for(int i = 0; i < 15; i++)
            {
                try
                {
                    context.Questions.AddOrUpdate(q => q.Text, new Question(loremIpsum[i], new List<string> { "Yes", "No", "Maybe" }, context.Users.Local.ToList()[i + 3]));
                }
                catch
                {
                    //Do nothing
                }
           }

            var questions = context.Questions.Local.ToList();
            var users = context.Users.Local.ToList();
            var rnd = new Random();
            for(int i = 0; i < 100; i++)
            {
                try
                {
                   var user = users[i];
                   for(int j = 0; j < 15; j++)
                   {
                       int option = rnd.Next(0, 10);
                       questions[j].Vote(user, option % 3); 
                   }
                }
                catch (Exception ex)
                {
                    //Do nothing
                }
            }

            context.SaveChanges();
        }

        //15 lorem ipsum questions
        List<string> loremIpsum = new List<string> 
        {
            "Curabitur vitae nisl ac sem varius ornare?", 
            "Vestibulum nec magna velit. Cras at velit in velit semper?",
            "ultricies rutrum non eros. Donec dui metus, euismod id?",
            "posuere sit amet, malesuada quis augue. Integer dictum eu risus ut mollis?",
            "Nullam porttitor suscipit eros, vitae dapibus nisl iaculis euismod?", //5
            "Quisque mattis gravida tortor, ac pulvinar ipsum varius in?",
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit?",
            "Nulla facilisi. Nullam ut vehicula urna?",
            "Pellentesque hendrerit dolor in lacus aliquet, vitae porttitor urna laoreet/",
            "Vestibulum congue facilisis ultricies?", //10
            "Donec malesuada, mi id laoreet euismod, lacus justo gravida dui?",
            "vitae ultrices magna turpis vitae tortor. Morbi quis pulvinar tellus?",
            "Vivamus nec sem nec nibh facilisis accumsan sit amet a nulla. Nullam quis urna tristique?",
            "ultrices leo vel, auctor est. Donec posuere, enim non varius placerat?",
            "nisl libero congue massa, sed accumsan metus ligula eu augue?"    
        };
    }
}
