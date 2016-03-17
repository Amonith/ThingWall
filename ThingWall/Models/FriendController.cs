using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThingWall.Data;
using ThingWall.Data.Model;

namespace ThingWall.Models
{
    public class FriendController : Controller
    {
        // GET: Friend
        [Authorize]
        public ActionResult AddFriend()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult AddFriend(FriendInvitation invit)
        {

            using (var ctx = new DataContext())
            {
                if (ctx.UserFriends.Where(x => x.User1 == invit.Recipient).FirstOrDefault() != null)
                {
                    if (ctx.UserFriends.Where(x => x.User2 == User.Identity.Name).FirstOrDefault() != null)
                    {
                        return RedirectToAction("FriendsList");
                    }
                }
                else if (ctx.UserFriends.Where(x => x.User2 == invit.Recipient).FirstOrDefault() != null)
                {
                    if (ctx.UserFriends.Where(x => x.User1 == User.Identity.Name).FirstOrDefault() != null)
                    {
                        return RedirectToAction("FriendsList");
                    }
                }
                if (invit.Recipient == User.Identity.Name)
                {
                    return RedirectToAction("FriendsList");
                }
                if (ctx.FriendInvitations.Where(x => x.Recipient == invit.Recipient && x.Sender == User.Identity.Name).FirstOrDefault() != null)
                {
                    return RedirectToAction("FriendsList");
                }
                if (ctx.Users.Where(x => x.UserName == invit.Recipient).FirstOrDefault() == null)
                {
                    return RedirectToAction("FriendsList");
                }

                FriendInvitation FriendToDatabase = new FriendInvitation();
                FriendToDatabase.FriendInvitationID = Guid.NewGuid();
                FriendToDatabase.Sender = User.Identity.Name;
                FriendToDatabase.Recipient = invit.Recipient;

                ctx.FriendInvitations.Add(FriendToDatabase);
                ctx.SaveChanges();

            }
            return View();
        }
        [Authorize]
        public ActionResult SendInvitationList()
        {
            using (var ctx = new DataContext())
            {
                List<FriendInvitation> invits = ctx.FriendInvitations.Where(x => x.Sender == User.Identity.Name && x.Status == false).ToList();
                return View(invits);
            }
        }
        [Authorize]
        public ActionResult Invitations()
        {
            using (var ctx = new DataContext())
            {
                List<FriendInvitation> invits = ctx.FriendInvitations.Where(x => x.Recipient == User.Identity.Name && x.Status == false).ToList();
                return View(invits);
            }
        }
        [Authorize]
        public ActionResult ConfimFreind(Guid? id)
        {

            using (var ctx = new DataContext())
            {
                if (id.HasValue)
                {
                    var user2 = ctx.FriendInvitations.Find(id);
                    var newFreind = new UserFriend();
                    newFreind.UserFriendID = Guid.NewGuid();
                    newFreind.User1 = user2.Recipient;
                    newFreind.User2 = user2.Sender;
                    ctx.FriendInvitations.Remove(user2);
                    ctx.UserFriends.Add(newFreind);
                    ctx.SaveChanges();
                    return RedirectToAction("Invitations");
                }
            }

            return View();
        }
        [Authorize]
        public ActionResult FriendsList()
        {
            using (var ctx = new DataContext())
            {
                var friendList = ctx.UserFriends.Where(x => x.User1 == User.Identity.Name).ToList();
                return View(friendList);
            }
        }
    }
}