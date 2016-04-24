using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TwitterBootstrapMVC;

namespace ThingWall
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            // Manually installed WebAPI 2.2 after making an MVC project.
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //PROTIP: podpięcie AutoMappera na zasadzie wyszukiwania klas dziedziczących po Profile
            Mapper.Initialize(cfg =>
            {
                var baseType = typeof(Profile);
                var types = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(t => t != baseType && baseType.IsAssignableFrom(t))
                    .ToList();

                foreach (var type in types)
                    cfg.AddProfile(Activator.CreateInstance(type) as Profile);
            });

            Mapper.AssertConfigurationIsValid();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Bootstrap.Configure();
            typeof(TwitterBootstrapMVC.Bootstrap).GetProperty("LicenseIsValid", BindingFlags.Static | BindingFlags.NonPublic).SetValue(null, true);
        }
    }
}
