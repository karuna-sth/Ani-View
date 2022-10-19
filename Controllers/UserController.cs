using AniView.Data;
using AniView.Models;
using Microsoft.AspNetCore.Mvc;

namespace AniView.Controllers
{
    public class UserController : Controller
    {
        private readonly AuthDbContext _context;
        public UserController(AuthDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AnimeList()
        {
            return View(_context.Animes);
        }
        public IActionResult Edit(int Id)
        {
            return View(_context.Animes.Where(a => a.AnimeId == Id).FirstOrDefault());
        }
        [HttpPost]
        public IActionResult Edit(AnimeInfo info)
        {
            _context.Animes.Update(info);
            _context.SaveChanges();
            TempData["Success"] = "Edited And Updated Successfully";
            return RedirectToAction("AnimeList");
        }
    }
}
