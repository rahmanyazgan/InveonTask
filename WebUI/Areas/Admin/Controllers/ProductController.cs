using BusinessLogicLayer.Interfaces;
using Entities.Concrete;
using System.Linq;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService ProductService;
        private readonly ISystemUserService SystemUserService;

        public ProductController(IProductService _ProductService,
            ISystemUserService _SystemUserService)
        {
            ProductService = _ProductService;
            SystemUserService = _SystemUserService;
        }

        public ActionResult Index()
        {
            var products = ProductService.GetProducts();
            var productViewModels = products.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Barcode = p.Barcode,
                Price = p.Price,
                Description = p.Description,
                Quantity = p.Quantity,
                CreatedDate = p.CreatedDate,
                CreatedBy = p.CreatedBy,
                UpdatedDate = p.UpdatedDate,
                UpdatedBy = p.UpdatedBy,
                IsDeleted = p.IsDeleted
            }).ToList();

            return View(productViewModels);
        }

        public ActionResult Create()
        {
            return View(new ProductViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Name = model.Name,
                    Barcode = model.Barcode,
                    Price = model.Price,
                    Description = model.Description,
                    Quantity = model.Quantity,
                    CreatedDate = System.DateTime.Now,
                    CreatedBy = 1 // Giriş yapan kullanıcı ID'si
                };

                ProductService.Add(product);
                TempData["SuccessMessage"] = "Ürün başarıyla eklendi.";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var product = ProductService.GetById(id);
            if (product == null)
            {
                TempData["ErrorMessage"] = "Ürün bulunamadı.";
                return RedirectToAction("Index");
            }

            var viewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Barcode = product.Barcode,
                Price = product.Price,
                Description = product.Description,
                Quantity = product.Quantity,
                CreatedDate = product.CreatedDate,
                CreatedBy = product.CreatedBy,
                UpdatedDate = product.UpdatedDate,
                UpdatedBy = product.UpdatedBy,
                IsDeleted = product.IsDeleted
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = ProductService.GetById(model.Id);
                if (product != null)
                {
                    product.Name = model.Name;
                    product.Barcode = model.Barcode;
                    product.Price = model.Price;
                    product.Description = model.Description;
                    product.Quantity = model.Quantity;
                    product.UpdatedDate = System.DateTime.Now;
                    product.UpdatedBy = 1; // Giriş yapan kullanıcı ID'si

                    ProductService.Update(product);
                    TempData["SuccessMessage"] = "Ürün başarıyla güncellendi.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = "Ürün bulunamadı.";
                }
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var product = ProductService.GetById(id);
            if (product == null)
            {
                TempData["ErrorMessage"] = "Ürün bulunamadı.";
                return RedirectToAction("Index");
            }

            var viewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Barcode = product.Barcode,
                Price = product.Price,
                Description = product.Description,
                Quantity = product.Quantity,
                CreatedDate = product.CreatedDate
            };

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var product = ProductService.GetById(id);
                if (product != null)
                {
                    ProductService.Delete(product);
                    TempData["SuccessMessage"] = "Ürün başarıyla silindi.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Ürün bulunamadı.";
                }
            }
            catch
            {
                TempData["ErrorMessage"] = "Ürün silinirken bir hata oluştu.";
            }

            return RedirectToAction("Index");
        }
    }
}