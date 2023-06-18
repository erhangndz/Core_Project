using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {

        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
           
            var values= _serviceService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            
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
