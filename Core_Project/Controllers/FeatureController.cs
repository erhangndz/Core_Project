using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.v1 = "Öne Çıkan Düzenleme";
            ViewBag.v2 = "Öne Çıkanlar";
            ViewBag.v3 = "Düzenleme";
            var values = _featureService.TGetByID(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(Feature p)
        {

            _featureService.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
