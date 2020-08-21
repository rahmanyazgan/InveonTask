using Autofac;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Interfaces;
using System.Data.Entity;

namespace WebUI.Modules
{
    public class EfModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InveonTaskContext>().As<DbContext>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
        }
    }
}
