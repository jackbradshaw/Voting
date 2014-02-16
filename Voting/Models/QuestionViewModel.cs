using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Voting.Domain.QuestionAggregate;

namespace Voting.Models
{
    public class QuestionViewModel
    {
        public QuestionViewModel() { }

        public QuestionViewModel(Question question) 
        {
            Id = question.Id;
            Question = question.Text;
            Options = question.Options.Select(option => new OptionViewModel(option)).ToList();
        }

        public Guid Id { get; set; }

        public string Question { get; set; }

        public List<OptionViewModel> Options { get; set; }

        public static QuestionViewModel NewRandomQuestion(Random rnd)
        {
            var vm = new QuestionViewModel();
            vm.Id = Guid.NewGuid();
            vm.Question = "";
            for (int i = 0; i < rnd.Next(5, 20); i++)
            {
                vm.Question += "Question ";
            }
            vm.Options = new List<OptionViewModel>
                {
                    new OptionViewModel{ Key = 1, Value="Its Great!", NumberOfVotes = 23 },
                    new OptionViewModel{ Key = 1, Value="Leave me alone!", NumberOfVotes = 7 },
                    new OptionViewModel{ Key = 1, Value="Its Rubbish!", NumberOfVotes = 14 }
                };

            return vm;
        }
    }
}