using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PigGame.Models;

namespace PigGame.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var sess = new GameSession(HttpContext.Session);
            var game = sess.GetGame();
            if (game.GameOver)
            {
                TempData["message"] =$"{game.CurrentPlayer} is The Winner";
            }
            return View(game);
        }

        [HttpPost]
        public IActionResult NewGame() 
        {
            var sess = new GameSession(HttpContext.Session);
            var game = sess.GetGame();

            game.NewGame();

            sess.SetGame(game);
            return View("Index");


        }
    }
}
