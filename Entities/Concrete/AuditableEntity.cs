using Entities.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{

    public abstract class AuditableEntity<T> : Entity<T>, IAuditableEntity
    {
        [ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; }

        [MaxLength(255)]
        [ScaffoldColumn(false)]
        public string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime UpdatedDate { get; set; }

        [MaxLength(255)]
        [ScaffoldColumn(false)]
        public string UpdatedBy { get; set; }

        public bool IsDeleted { get; set; }
    }

}
