using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Core_Project.Areas.Writer.ViewComponents
{
    public class _NavbarWriter:ViewComponent
    {
        private readonly UserManager<WriterUser> _userManager;

        public _NavbarWriter(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values= await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = values.ImageURL;
            return View();
        }
    }
}
