using Entities.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public abstract class BaseEntity
    {
    }

    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        [Key]
        public virtual T Id { get; set; }
    }
}
