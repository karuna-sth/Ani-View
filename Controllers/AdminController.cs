using AniView.Data;
using AniView.Models;
using AniView.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AniView.Controllers
{
    public class AdminController : Controller
    {
        private readonly AuthDbContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public AdminController (AuthDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnviroment = webHostEnvironment;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Obsolete]
        public IActionResult Index(AnimeInfoCreateModel info)
        {
            var filePath = "images/Animes/" + Guid.NewGuid().ToString() + info.Image.FileName ;
            var fullPath = Path.Combine(_webHostEnviroment.WebRootPath, filePath);
            UploadFile(info.Image, fullPath);
            AnimeInfo data = new AnimeInfo()
            {
                AnimeName = info.AnimeName,
                AnimeDescription = info.AnimeDescription,
                Image = "/"+ filePath
            };
            _context.Animes.Add(data);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public void UploadFile(IFormFile file, string path)
        {
            FileStream stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);
        }
    }
}
