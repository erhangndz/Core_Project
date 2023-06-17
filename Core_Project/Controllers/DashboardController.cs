using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
