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
    public class ListsController : Controller
    {
        //
        // GET: /List/

        public ActionResult Index()
        {
            IEnumerable<UserList> usersList;
            using (YearnlyEntities context = new YearnlyEntities())
            {
                usersList = context.UserLists.Where(ul => ul.UserId == WebSecurity.CurrentUserId).ToList();
            }
            ViewBag.UsersLists = usersList;
            return View();
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            UserList editList;
            using (YearnlyEntities context = new YearnlyEntities())
            {
               editList = context.UserLists.Where(ul => ul.Id == id).FirstOrDefault();
            }
            ViewBag.EditList = editList;
            return View();
        }

        [HttpPost]
        public ActionResult Create(String listname)
        {
            UserList newList = new UserList();
            newList.Name = listname;
            newList.UserId = WebSecurity.CurrentUserId;
            newList.DateCreated = DateTime.UtcNow;
            using (YearnlyEntities context = new YearnlyEntities())
            {
                context.UserLists.Add(newList);
                context.SaveChanges();
            }
            return RedirectToAction("index", "list");
        }
    }
}
