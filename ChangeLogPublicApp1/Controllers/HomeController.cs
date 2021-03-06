﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChangeLogPublicApp1.Models;
using ChangeLogPublicApp.DataAccess;

namespace ChangeLogPublicApp1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            MongoDataAccess da = new MongoDataAccess();
            var changeloglist = da.GetChangeLogs();
            return View(changeloglist);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
