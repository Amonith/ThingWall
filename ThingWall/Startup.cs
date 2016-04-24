using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ThingWall.Startup))]
namespace ThingWall
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            //PROTIP: podpięcie SignalR
            app.MapSignalR();
        }
    }
}
