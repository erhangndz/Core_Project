using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.v1 = "Hakkımda Düzenleme";
            ViewBag.v2 = "Hakkımda";
            ViewBag.v3 = "Düzenleme";
            var values = _aboutService.TGetByID(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(About p)
        {

            _aboutService.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
