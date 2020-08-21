using BusinessLogicLayer.Interfaces;
using System.Web.Mvc;

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
            return View();
        }
    }
}