using AniView.Data;
using AniView.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AniView.Controllers
{
    public class AdminController : Controller
    {
        private readonly AuthDbContext _context;
        public AdminController (AuthDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AnimeInfo info)
        {
            _context.Animes.Add(info);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
