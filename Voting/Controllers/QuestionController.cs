using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Voting.Data;
using Voting.Data.Repositories;
using Voting.Domain;
using Voting.Domain.Exceptions;
using Voting.Domain.QuestionAggregate;
using Voting.Models;

namespace Voting.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        private IVotingContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;


        public QuestionController()
        {
            _dbContext = new VotingContext();
            _unitOfWork = new UnitOfWork(_dbContext, new QuestionRepository(_dbContext), new UserRepository(_dbContext));
        }
        //
        // GET: /Question/
        public ActionResult Index()
        {
            var username = User.Identity.Name;

            var user = _unitOfWork.UserRepository.Get(u => u.Name == username).SingleOrDefault();

            ViewBag.UserPoints = user.Points;

            return View();
        }

        public JsonResult GetQuestions()
        {

            //Random rnd = new Random();

            //var questions = new List<QuestionViewModel>();
            //for (int i = 0; i < 20; i++)
            //{
            //    questions.Add(QuestionViewModel.NewRandomQuestion(rnd));
            //}

            //var questionViewmodels = questions;
            var questions = _unitOfWork.QuestionRepository.GetAll();

            var questionViewmodels = questions.Select(q => new QuestionViewModel(q));           

            return Json(questionViewmodels, JsonRequestBehavior.AllowGet);
        }

        public JsonResult VoteFor(Guid questionId, int optionKey)
        {
            var voteResponse = new VoteResponse();
            voteResponse.Code = -1;

            try
            {
                var username = User.Identity.Name;

                var user = _unitOfWork.UserRepository.Get(u => u.Name == username).SingleOrDefault();

                var question = _unitOfWork.QuestionRepository.GetById(questionId);

                question.Vote(user, optionKey);

                _unitOfWork.Save();

                 voteResponse.Code = 1;
                 voteResponse.UserPoints = user.Points;
            }          
            catch(AlreadyVotedException)
            {
                 voteResponse.Code = 2;
            }

            return Json(voteResponse, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAddQuestion()
        {
            return View();
        }

        public JsonResult AddNewQuestion(NewQuestionModel model)
        {
            var questionAdded = new QuestionAddedViewModel();
            questionAdded.Code = -1;

            try
            {
                var username = User.Identity.Name;

                var user = _unitOfWork.UserRepository.Get(u => u.Name == username).SingleOrDefault();

                if (user == null) return Json(false, JsonRequestBehavior.AllowGet);

                var newQuestion = new Question(model.Question, model.Options, user);

                _unitOfWork.QuestionRepository.Add(newQuestion);

                _unitOfWork.Save();

                questionAdded.Code = 1;
                questionAdded.Question = new QuestionViewModel(newQuestion);
                questionAdded.UserPoints = user.Points;

                return Json(questionAdded, JsonRequestBehavior.AllowGet);
            }
            catch (NotEnoughPointsException ex)
            {
                throw;
            }
        }
	}
}