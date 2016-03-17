using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThingWall.Data;
using ThingWall.Data.Model;
using ThingWall.Models;
using Microsoft.AspNet.Identity;

namespace ThingWall.Controllers
{
    public class ItemsController : Controller
    {
        // GET: Items
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Create(string id)
        {
            using (var ctx = new DataContext())
            {
                
                if (ctx.Users.Find(id) == null)
                {
                    id = User.Identity.GetUserId();
                }
                var user = ctx.Users.Find(id);
                var model = new CreateViewModel();
                model.Username = user.Email;

                return View(model);
            }
        }
        [HttpPost]
        [Authorize]
        public ActionResult Create(string id, ItemViewModels newItem)
        {
            if (ModelState.IsValid)
            {
                using (var ctx = new DataContext())
                {
                    if (ctx.Users.Find(id) == null)
                    {
                        id = User.Identity.GetUserId();
                    }

                    Item itemToDatabase = new Item();
                    itemToDatabase.Name = newItem.Name;
                    itemToDatabase.Description = newItem.Description;
                    itemToDatabase.CreateDate = DateTime.Now.Date;
                    itemToDatabase.OwnerId = id;


                    ctx.Items.Add(itemToDatabase);
                    ctx.SaveChanges();
                }
            }
            return View();
        }
        [Authorize]
        public ActionResult CurrentUserItems()
        {
            using (var ctx = new DataContext())
            {
                string UserID = User.Identity.GetUserId();
                var ItemsList = ctx.Items.Where(x => x.OwnerId == UserID).ToList();

                return View(ItemsList);
            }
        }

    }
}