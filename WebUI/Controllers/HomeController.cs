using BusinessLogicLayer.Interfaces;
using System.Web.Mvc;

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
            var products = ProductService.GetProducts();
            return View(products);
        }
    }
}