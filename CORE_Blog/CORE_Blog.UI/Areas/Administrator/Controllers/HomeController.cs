﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE_Blog.UI.Areas.Administrator.Controllers
{
    public class HomeController : Controller
    {
        [Area("Administrator"), Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
