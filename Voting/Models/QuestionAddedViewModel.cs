using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Voting.Models
{
    public class QuestionAddedViewModel
    {
        public int Code { get; set; }

        public QuestionViewModel Question { get; set; }

        public int UserPoints { get; set; }
    }
}