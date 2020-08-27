using System;
using System.Collections.Generic;

namespace WebUI.Models
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            Images = new List<Entities.Concrete.Image>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public bool IsDeleted { get; set; }

        public List<Entities.Concrete.Image> Images { get; set; }

    }
}