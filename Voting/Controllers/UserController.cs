using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Voting.Data;
using Voting.Data.Repositories;
using Voting.Domain;
using Voting.Domain.UserAggregate;
using Voting.Models;

namespace Voting.Controllers
{
    public class UserController : Controller
    {
        private IVotingContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        public UserController()
        {
            _dbContext = new VotingContext();
            _unitOfWork = new UnitOfWork(_dbContext, new QuestionRepository(_dbContext), new UserRepository(_dbContext));
        }

        //
        // GET: /User/
        public ActionResult Index()
        {
            return View(new SignInViewModel());
        }

        public ActionResult FormSubmit(SignInViewModel viewmodel)
        {
            if (viewmodel.Button == viewmodel.SignIn)
                return SignIn(viewmodel.Username);
            //if (viewmodel.Button == viewmodel.Register)
            return Register(viewmodel.Username); 
        }

        private ActionResult SignIn(string username)
        {
            //Try and get the User:
            var user = _unitOfWork.UserRepository.Get(u => u.Name == username).SingleOrDefault();

            if (user == null) throw new Exception(); //persist model state and refierct to index?

            //Set user Id in cookie and redirect to Question Page:
            FormsAuthentication.SetAuthCookie(username, true);

            return RedirectToAction("Index", "Question");
        }

        private ActionResult Register(string username)
        {
            try
            {
                var newuser = new User(username);

                _unitOfWork.UserRepository.Add(newuser);

                _unitOfWork.Save();

                FormsAuthentication.SetAuthCookie(username, true);
            }catch
            {
                //persist model state and refierct to index?
                throw;
            }

            return RedirectToAction("Index", "Question");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "User");
        }


        /// <summary>
        /// Note this method is for user friendly feedback
        /// and does not constitue a fool proof check.
        /// 
        /// The unique condition is enfored by a uniquess constraint on the database column.
        /// A full concurrency safe domain implementation would be complicated,
        /// and since it is a very common concern and not novel to this domain, it is not modelled there.
        /// </summary>
        /// <returns></returns>
        public bool IsUserNameAvailible(string username)
        {
            return _unitOfWork.UserRepository.Get(u => u.Name == username).Count() == 0;
        }
	}
}