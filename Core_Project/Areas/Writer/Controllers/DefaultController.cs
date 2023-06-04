using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

     
    }
}
