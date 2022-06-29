using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptionPatternTask.Models;
using System.Diagnostics;

namespace OptionPatternTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        //EagerLoding
        public async Task<IActionResult> Index()
        {
            var user = _context.Students.Include(s => s.Standard);
            return View(await user.ToListAsync());
        }
        //LazyLoading
        public async Task<IActionResult> LazyLoading()
        {
            var user = await _context.Students.ToListAsync();
            return View(user);
        }
        //ExpliciteLoad
        public async Task<IActionResult> ExplicitLoading()
        {



            var user = _context.Students.Where(s => s.StudentName == "Abaseen").FirstOrDefault();
             _context.Entry(user).Reference(c =>c.Standard).Load();

            return View(user);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}