using BusinessLogicLayer.Interfaces;
using Core.Utilities;
using Entities.Concrete;
using System.Collections.Generic;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService ProductService;
        private readonly ISystemUserService SystemUserService;

        public HomeController(IProductService _ProductService,
            ISystemUserService _SystemUserService)
        {
            ProductService = _ProductService;
            SystemUserService = _SystemUserService;
        }

        public ActionResult Index()
        {
            var data = ProductService.GetProducts();
            var products = new List<ProductViewModel>();

            foreach (var item in data)
            {
                var model = new ProductViewModel();
                SimpleMapper.PropertyMap(item, model);
                products.Add(model);
            }

            ViewBag.Title = "Test";

            return View(products);
        }
    }
}