using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamesRent.Models;

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
            var games = _context.Games.ToList();
            return View(games);
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
    }
}