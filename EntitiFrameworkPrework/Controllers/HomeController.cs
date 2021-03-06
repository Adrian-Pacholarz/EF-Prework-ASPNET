﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EntitiFrameworkPrework.Models;
using EntitiFrameworkPrework.ORM;
using EntitiFrameworkPrework.Repositories;

namespace EntitiFrameworkPrework.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var allTeams = _unitOfWork.Teams.GetAll();
            var allMatches = _unitOfWork.Matches.GetAll();

            return View(new TeamMatchViewModel {teams = allTeams, matches = allMatches });
        }

        public IActionResult BestTeam()
        {
            var bestTeam = _unitOfWork.Teams.GetBestTeam();
            return View(bestTeam);
        }

        public IActionResult FCTeams()
        {
            var FCTeams = _unitOfWork.Teams.GetTeamsContainingFC();
            return View(FCTeams);
        }

        public IActionResult TeamsGoals()
        {
            var TeamGoals = _unitOfWork.Teams.GetTeamsWithGoals();
            return View(TeamGoals);
        }

        public IActionResult TeamsMoreThanMatch()
        {
            var TeamsPlayedMore = _unitOfWork.Teams.GetTeamsPlayedMoreMatches();
            return View(TeamsPlayedMore);
        }

        public IActionResult MostGoals()
        {
            var MostGoals = _unitOfWork.Matches.GetMostGoalsMatch();
            return View(MostGoals);
        }

        public IActionResult MatchesLastWeek()
        {
            var MatchesLastWeek = _unitOfWork.Matches.GetMatchesFromLastWeek();
            return View(MatchesLastWeek);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
