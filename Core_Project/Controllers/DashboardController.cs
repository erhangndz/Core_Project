using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Core_Project.Controllers
{
    public class DashboardController : Controller
    {
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
