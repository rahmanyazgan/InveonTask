using Autofac;
using Autofac.Integration.Mvc;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Interfaces;
using System.Data.Entity;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using WebUI.Modules;

namespace WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            #region Autofac Configuration
            var builder = new Autofac.ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();

            builder.RegisterModule(new EfModule());
            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new RepositoryModule());

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            #endregion

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
