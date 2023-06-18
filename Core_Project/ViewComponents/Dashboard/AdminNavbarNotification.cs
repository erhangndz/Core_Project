using Microsoft.AspNetCore.Mvc;

namespace Core_Project.ViewComponents.Dashboard
{
    public class AdminNavbarNotification:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
