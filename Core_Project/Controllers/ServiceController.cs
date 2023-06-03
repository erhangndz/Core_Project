using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            ViewBag.v1 = "Hizmet Listesi";
            ViewBag.v2 = "Hizmetler";
            ViewBag.v3 = "Hizmet Listesi";
            var values= _serviceService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            ViewBag.v1 = "Hizmet Ekleme";
            ViewBag.v2 = "Hizmetler";
            ViewBag.v3 = "Ekleme";
            return View();
        }
        [HttpPost]
        public IActionResult AddService(Service p)
        {
            _serviceService.TInsert(p);
            return RedirectToAction("Index");
        }


        public IActionResult DeleteService(int id)
        {
            var values = _serviceService.TGetByID(id);
            _serviceService.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            ViewBag.v1 = "Hizmet Düzenleme";
            ViewBag.v2 = "Hizmetler";
            ViewBag.v3 = "Düzenleme";
            var values = _serviceService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateService(Service p)
        {

            _serviceService.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
