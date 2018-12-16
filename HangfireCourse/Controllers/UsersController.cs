using System;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
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
            
            var jobId = BackgroundJob.Enqueue(() => Information("BackgroundJob.Enqueue - executed!"));
            return View(await _context.Users.ToListAsync());
        }


        public async Task<IActionResult> Hello(string id)
        {
            var user = _context.Users.FirstOrDefault(n => n.Id == id);
            if (user != null) BackgroundJob.Enqueue(() => HelloUser(user));

            return RedirectToAction("Index");
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

        public void Information(string value) => _logger.LogInformation(value);
        public void HelloUser(User user) => _logger.LogInformation($"Hello {user.Username} ({user.Email}) ");
    }
}
