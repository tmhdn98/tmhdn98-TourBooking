﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IUH.TOURBOOKING.WEBSITE.ViewComponents
{
    public class Theme : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}