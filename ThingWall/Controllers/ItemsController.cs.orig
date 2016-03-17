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
<<<<<<< HEAD
        public ActionResult Create(ItemViewModels newItem, Guid? id)
=======
        public ActionResult Create(string id, ItemViewModels newItem)
>>>>>>> master
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
<<<<<<< HEAD
                    if (id.HasValue)
                    {
                        var target = ctx.UserFriends.Where(x => x.UserFriendID == id.Value).FirstOrDefault();
                        if (target.User1 == User.Identity.Name)
                        {
                            var findId = ctx.Users.Where(x => x.UserName == target.User2).FirstOrDefault();
                            itemToDatabase.OwnerId = findId.Id;
                        }
                        else
                        {
                            var findId = ctx.Users.Where(x => x.UserName == target.User1).FirstOrDefault();
                            itemToDatabase.OwnerId = findId.Id;
                        }
                    }
                    else
                    {
                        itemToDatabase.OwnerId = User.Identity.GetUserId();
                    }
=======
                    itemToDatabase.OwnerId = id;
>>>>>>> master

                    itemToDatabase.AuthorID = User.Identity.GetUserId();

                    ctx.Items.Add(itemToDatabase);
                    ctx.SaveChanges();
                    if (!id.HasValue)
                        return RedirectToAction("CurrentUserItems");
                }
            }
            return View();
        }
        [Authorize]
        public ActionResult CurrentUserItems(Guid? id)
        {
            using (var ctx = new DataContext())
            {
                if (id.HasValue)
                {
                    var user = ctx.UserFriends.Find(id);
                    
                    if (user.User1 == User.Identity.Name)
                    {
                        var userid = ctx.Users.Where(x => x.UserName == user.User2).FirstOrDefault();
                        var ItemsList1 = ctx.Items.Where(x => x.OwnerId == userid.Id).ToList();
                        return View(ItemsList1);
                    }
                    else
                    {
                        var userid = ctx.Users.Where(x => x.UserName == user.User2).FirstOrDefault();
                        var ItemsList1 = ctx.Items.Where(x => x.OwnerId == userid.Id).ToList();
                        return View(ItemsList1);
                    }
                }


                string UserID = User.Identity.GetUserId();
                var ItemsList = ctx.Items.Where(x => x.OwnerId == UserID).ToList();

                return View(ItemsList);
<<<<<<< HEAD
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
=======
>>>>>>> master
            }
        }

    }
}