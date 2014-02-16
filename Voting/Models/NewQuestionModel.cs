using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Voting.Models
{
    public class NewQuestionModel
    {
        public string Question { get; set; }

        public List<string> Options { get; set; }
    }
}