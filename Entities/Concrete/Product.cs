using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Product : AuditableEntity<long>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Barcode { get; set; }

        public decimal Price { get; set; }

        public List<string> Images { get; set; }
        
        public string Description { get; set; }
        
        public int Quantity { get; set; }
    }
}
