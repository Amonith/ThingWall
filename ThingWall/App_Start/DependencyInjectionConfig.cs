﻿using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using ThingWall.Data;

namespace ThingWall
{
    public static class DependencyInjectionConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            RegisterServices(builder);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            var autofacResolver = new AutofacDependencyResolver(container);
            //var dependencyResolver = new InjectableDependencyResolver(diContainer, autofacResolver);
            DependencyResolver.SetResolver(autofacResolver);
        }

        public static void RegisterServices(ContainerBuilder c)
        {
            c.RegisterType<DataContext>().InstancePerDependency();
        }
    }
}