using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using Yearnly.Model;

namespace Yearnly.Web.Controllers
{
    [Authorize]
    public class ItemsController : Controller
    {
        //
        // GET: /Items/

        public ActionResult Index()
        {
            List<UserItem> UserItems;
            using (YearnlyEntities context = new YearnlyEntities())
            {
                UserItems = context.UserItems.Where(ui => ui.UserId == WebSecurity.CurrentUserId).ToList();
            }
            ViewBag.UserItems = UserItems;
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserItem input)
        {
            input.UserId = WebSecurity.CurrentUserId;
            using (YearnlyEntities context = new YearnlyEntities())
            {
                context.UserItems.Add(input);
                context.SaveChanges();
            }
            return RedirectToAction("index", "items");
        }

    }
}
