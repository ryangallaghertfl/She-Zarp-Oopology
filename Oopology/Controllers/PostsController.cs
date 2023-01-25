using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Oopology.Data;
using Oopology.Models;


public class PostsController : Controller
{
    private readonly ILogger<PostsController> _logger;
    private readonly OopologyContext _context;


    public PostsController(ILogger<PostsController> logger, OopologyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [Route("/posts")]
    [HttpGet]
    public IActionResult Index()
    {
        var posts = _context.Post
          .Include(p => p.User)
          .OrderByDescending(p => p.Id)
          .ToList();
        return View(posts);
    }




    [Route("/posts")]
    [HttpPost]
    public IActionResult Create(Post post)
    {
        if (string.IsNullOrWhiteSpace(post.Content))
        {
            return RedirectToAction("Index");
        }
        else
        {
            int currentUserId = HttpContext.Session.GetInt32("User_Id").Value;
            post.UserId = currentUserId;
            _context.Post.Add(post);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }


}

