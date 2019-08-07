using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using EIP.Entities;

namespace sb_admin_2.Web.App_Start
{
    public class AutofacConfig
    {
        public static void Bootstrapper()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<EipDbContext>()
                .As<IEipDbContext>()
                .InstancePerRequest();

            var container = builder.Build();

            var resolver = new AutofacDependencyResolver(container);

            DependencyResolver.SetResolver(resolver);
        }
    }
}