using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Product : AuditableEntity<int>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Barcode { get; set; }

        [Required]
        public decimal Price { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
