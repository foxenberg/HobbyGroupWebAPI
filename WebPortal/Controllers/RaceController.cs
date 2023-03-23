using Microsoft.AspNetCore.Mvc;
using WebPortal.Data;
using WebPortal.Models;

namespace WebPortal.Controllers
{
    public class RaceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RaceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Race> races = _context.Races.ToList();
            return View(races);
        }
        public IActionResult Detail(int id)
        {
            Race race = _context.Races.FirstOrDefault(c => c.Id == id);
            return View(race);
        }
    }
}
