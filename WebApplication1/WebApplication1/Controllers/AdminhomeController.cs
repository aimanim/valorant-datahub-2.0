﻿using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class AdminhomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AdminhomeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var hehe = _db.users.ToList();
            TempData["Users"] = $"{hehe.Count}";
            return View();
        }
    }
}
