﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Yearnly.Web.Controllers
{
    public class ItemsController : Controller
    {
        //
        // GET: /Items/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public void Create(FormCollection form)
        {
            
        }

    }
}
