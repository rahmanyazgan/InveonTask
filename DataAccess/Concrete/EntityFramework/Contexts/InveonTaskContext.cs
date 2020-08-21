using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading;
using Entities.Concrete;
using Entities.Interfaces;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public interface IContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<SystemUser> SystemUsers { get; set; }

        DbSet<Image> Images{ get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }

    public class InveonTaskContext : DbContext, IContext
    {
        public InveonTaskContext() : base("Name=InveonTaskContext")
        {
            // this.Configuration.LazyLoadingEnabled = false; 
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<SystemUser> SystemUsers { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity
                    && (x.State == EntityState.Added || 
                    x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as IAuditableEntity;

                if (entity != null)
                {
                    var now = DateTime.Now;

                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedDate = now;
                    }
                    else
                    {
                        base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }

                    entity.UpdatedDate = now;
                }
            }
            return base.SaveChanges();
        }
    }
}
