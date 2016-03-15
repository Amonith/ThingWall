using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThingWall.Data;
using ThingWall.Data.Model;
using ThingWall.Models;
using Microsoft.AspNet.Identity;
using System.Net;

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
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult Create(ItemViewModels newItem, Guid? id)
        {
            if (ModelState.IsValid)
            {
                using (var ctx = new DataContext())
                {
                    Item itemToDatabase = new Item();
                    itemToDatabase.Name = newItem.Name;
                    itemToDatabase.Description = newItem.Description;
                    itemToDatabase.CreateDate = DateTime.Now.Date;
                    if (id.HasValue)
                    {
                        itemToDatabase.OwnerId = id.Value.ToString();
                    }
                    else
                    {
                        itemToDatabase.OwnerId = User.Identity.GetUserId();
                    }

                    itemToDatabase.AuthorID = User.Identity.GetUserId();

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
        public ActionResult Details(int? id)
        {
            ItemViewModels items = new ItemViewModels();
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var ctx = new DataContext())
            {
                var itemDetail = ctx.Items.Find(id.Value);
                items.Name = itemDetail.Name;
                items.Description = itemDetail.Description;
                items.CreateDate = itemDetail.CreateDate;
                if (itemDetail == null)
                    return HttpNotFound();
                
                return View(items);
            }
        }
    }
}