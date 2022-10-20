using AniView.Data;
using AniView.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

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
        public IActionResult Delete(int id)
        {
            AnimeInfo info = _context.Animes.Where(a => a.AnimeId == id).FirstOrDefault();
            _context.Animes.Remove(info);
            _context.SaveChanges();
            TempData["Success"] = "Deleted Successfully";
            return RedirectToAction("AnimeList");
        }
        [HttpPost]
        public IActionResult Edit(AnimeInfo info)
        {
            _context.Attach<AnimeInfo>(info);
            _context.Entry(info).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            TempData["Success"] = "Edited And Updated Successfully";
            return RedirectToAction("AnimeList");
        }
        public IActionResult Details(int id)
        {
            AnimeInfo info = _context.Animes.Where(a => a.AnimeId == id).FirstOrDefault();
            return View(info);
        }
    }
}
