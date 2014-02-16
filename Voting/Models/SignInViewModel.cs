using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Voting.Models
{
    public class SignInViewModel
    {
        public string Username { get; set; }

        public string Button { get; set; }

        public string SignIn = "signin";

        public string Register = "register";
    }
}