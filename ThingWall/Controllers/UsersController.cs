using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThingWall.Data;

namespace ThingWall.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UsersList()
        {
            using (var ctx = new DataContext())
            {
                var Users = ctx.Users.ToList();
                return View(Users);
            }
        }
    }
}