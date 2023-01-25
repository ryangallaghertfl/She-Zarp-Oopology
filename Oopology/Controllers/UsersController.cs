using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Oopology.Data;
using Oopology.Models;

namespace Oopology.Controllers
{
    public class UsersController : Controller
    {
        private readonly OopologyContext _context;

        public UsersController(OopologyContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return _context.User != null
                ? View(await _context.User.ToListAsync())
                : Problem("Entity set 'OopologyContext.User'  is null.");
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,XpLevel,Email,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,XpLevel,Email,Password")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.User == null)
            {
                return Problem("Entity set 'OopologyContext.User'  is null.");
            }

            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return (_context.User?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [Route("/signup")]
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [Route("/signup")]
        [HttpPost]
        public IActionResult Signup(string name, string email, string password)
        {
            if (name == null || email == null || password == null)
            {

            }

            User user = new User();
            user.Email = email;
            user.Password = password;
            user.Name = name;
            user.XpLevel = 0;
            _context.Add(user);
            _context.SaveChanges();
            return Redirect("/Login");

        }

        [Route("/login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Route("/login")]
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // First checks whether an email and password have actually been sent
            if (email != null || password != null)
            {
                // If that is the case, it tries to find a User in the db that matches that email and password combo
                var user = _context.User.Where(user => user.Email == email && user.Password == password).ToList().FirstOrDefault();
                // Then if that email is found, and the password matches....
                if (user != null)
                {
                    // It sets the Session UserId value as the user ID, and sends them to their dashboard
                    HttpContext.Session.SetInt32("User_Id", user.Id);
                    return new RedirectResult("/dashboard");
                }
                // If the wrong email or password is submitted...
                TempData["UserEmailOrPasswordIsNullWhenLoggingOn"] = "Incorrect login credentials!";
                return new RedirectResult("/login");
            }
            // If the email or password is null. 
            TempData["UserEmailOrPasswordIsNullWhenLoggingOn"] = "You must submit an email and password!";
            return new RedirectResult("/login");
        }

        // disabled until Purchase class implemented
        //[Route("/dashboard")]
        //[HttpGet]
        //public IActionResult Dashboard()
        //{
        //    var userId = HttpContext.Session.GetInt32("User_Id");
        //    if (userId == null)
        //    {
        //        Console.WriteLine("wrong username");
        //        return new RedirectResult("/login");
        //    }
            
        //    var user = _context.User.Include(p => p.Purchases).ToList().First();
        //    return View(user);

        //}
        [Route("/leaderboard")]
        [HttpGet]
        public IActionResult Leaderboard()
        {
            var userId = HttpContext.Session.GetInt32("User_Id");
            if (userId == null)
            {
                Console.WriteLine("wrong username");
                return new RedirectResult("/login");
            }

            var userList = _context.User.ToList().OrderBy(u => u.XpLevel);
            return View(userList);

        }

    }
}

