using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Routing;

namespace ThingWall.Hubs
{
    public class NotificationsHub : Hub
    {
        public override Task OnConnected()
        {
            string name = Context.User.Identity.Name;

            //TODO: pobierz login użytkownika
            //TODO: pobierz oczekujące notyfikacje z kolejki
            //TODO: wyświetl je użytkownikowi
            //TODO: zapamiętaj, powiązanie między loginem a połączeniem

            //TODO: ShowUnreadNotifications();
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {

            string name = Context.User.Identity.Name;
            //TODO: usuń połączenie między loginem a connectionId

            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            string name = Context.User.Identity.Name;

            return base.OnReconnected();
        }

        internal static void NotifyConnected(string notificationMessage, string targetUrl = "#")
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<NotificationsHub>();
            context.Clients.All.addMessage(notificationMessage, targetUrl);
        }

        //PROTIP: zwykłą funkcja publiczna w Hubie jest wywoływalna z JS
        public void NotifyAll(string notificationMessage, string targetUrl = "#")
        {
            NotifyConnected(notificationMessage, targetUrl);
        }
    }
}