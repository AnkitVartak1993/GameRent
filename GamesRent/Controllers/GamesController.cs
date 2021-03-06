﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamesRent.Models;
/// <summary>
/// Controller to handle Game Information related actions(new, edit,details, delete)
/// </summary>
namespace GamesRent.Controllers
{
    public class GamesController : Controller
    {
        private ApplicationDbContext _context;
        // GET: Games

            public GamesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {

            // var games = _context.Games.ToList();
            // return View(games);

            if (User.IsInRole("CanManageGames"))
                return View("Index");
            else
                return View("ReadOnlyList");
        }

        [Route("games/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int year, int month)
        {

            return View();
        }

        public ActionResult Details(int id)
        {
            var game = _context.Games.SingleOrDefault(g => g.Id == id);

            if (game == null)
                return HttpNotFound();

            return View(game);
        }

        [Authorize(Roles ="CanManageGames")]
        public ActionResult New()
        {
            var GameView = new Game();

            return View(GameView);
        }

        [Authorize(Roles = "CanManageGames")]
        [HttpPost]
        public ActionResult Save(Game game)
        {
            if (!ModelState.IsValid)
            {
                var GameModel = new Game { };
               
                return View("New", GameModel);
            }

                if (game.Id == 0)
            {
                _context.Games.Add(game);
            }
            else
            {

                var gameUpdate = _context.Games.Single(c => c.Id == game.Id);

                gameUpdate.Id = game.Id;
                gameUpdate.InStock = game.InStock;
                gameUpdate.GameAdded = game.GameAdded;
                gameUpdate.Genre = game.Genre;
                gameUpdate.Name = game.Name;
                gameUpdate.ReleaseDate = game.ReleaseDate;


            }


            _context.SaveChanges();

            return RedirectToAction("Index", "Games");
        }

        [Authorize(Roles = "CanManageGames")]
        public ActionResult Edit(int id)
        {
            var game = _context.Games.SingleOrDefault(c => c.Id == id);

            if (game == null)
                return HttpNotFound();

            var GameModel = game;
           
            return View("New", GameModel);

        }
    }
}