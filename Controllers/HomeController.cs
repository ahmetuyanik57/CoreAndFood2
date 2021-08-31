﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood2.Controllers
{
   
    public class HomeController : Controller
    {
        [AllowAnonymous]

        public IActionResult Index()
        {
            return View();
        }
    }
}