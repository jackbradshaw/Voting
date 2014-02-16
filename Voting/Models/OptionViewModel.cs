using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Voting.Domain.QuestionAggregate;

namespace Voting.Models
{
    public class OptionViewModel
    {
        public OptionViewModel() { }

        public OptionViewModel(Option option)
        {
            Key = option.Key;
            Value = option.Value;
            NumberOfVotes = option.NumberOfVotes;
        }

        public int Key { get; set; }

        public string Value { get; set; }

        public int NumberOfVotes { get; set; }
    }
}