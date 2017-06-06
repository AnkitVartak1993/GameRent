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
        // GET: Games
        public ActionResult Index()
        {
            var game = new Game() { Name = "GTA 5" };
            return View(game);
        }
    }
}