using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HangfireCourse.Data;
using HangfireCourse.Models;
using Microsoft.Extensions.Logging;

namespace HangfireCourse.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;

        public UsersController(AppDbContext context, ILogger<UsersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Index method!");
            return View(await _context.Users.ToListAsync());
        }
        
        //GET Users/Info
        public async Task<IActionResult> Info()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Username,Email")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
