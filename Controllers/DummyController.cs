﻿using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    public class DummyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
