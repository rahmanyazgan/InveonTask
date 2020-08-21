using Autofac;
using System.Linq;
using System.Reflection;

namespace BusinessLogicLayer.DependencyResolver.AutofacIOC.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("BusinessLogicLayer"))
                      .Where(t => t.Name.EndsWith("Service"))
                      .AsImplementedInterfaces()
                      .InstancePerLifetimeScope();

        }

    }
}
