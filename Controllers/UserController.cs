using AniView.Data;
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
    }
}
