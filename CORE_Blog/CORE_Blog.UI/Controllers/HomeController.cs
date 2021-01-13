﻿using CORE_Blog.UI.Models;
using CORE_Blog.CORE.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CORE_Blog.MODEL.Entities;

namespace CORE_Blog.UI.Controllers
{                
    public class HomeController : Controller
    {
        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
        private readonly ICoreService<Category> cs;
        private readonly ICoreService<Post> ps;
        private readonly ICoreService<User> us;
        private readonly ICoreService<Comment> cms;

        public HomeController (ICoreService<Category> _cs, ICoreService<Post> _ps, ICoreService<User> _us, ICoreService<Comment> _cms)
        {
            cs = _cs;
            us = _us;
            ps = _ps;
            cms = _cms;
        }
        public IActionResult Index()
        {
            return View(ps.GetActive());
        }

        public IActionResult PostByCategoryID(Guid id)
        {
            return View(ps.GetDefault(x => x.CategoryID == id).ToList());
        }

        public IActionResult Post(Guid id)
        {
            Post post = ps.GetByID(id);
            post.ViewCount++;
            ps.Update(post);

            return View(Tuple.Create<Post, User, List<Category>, List<Comment>>(post, us.GetByID(post.UserID), cs.GetActive(), cms.GetDefault(x => x.Post.ID == id)));
        }

    }
}
