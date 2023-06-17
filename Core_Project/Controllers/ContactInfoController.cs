using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    public class ContactInfoController : Controller
    {
        private readonly IContactInfoService _contactInfoService;

        public ContactInfoController(IContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values= _contactInfoService.TGetByID(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(ContactInfo p)
        {
            _contactInfoService.TUpdate(p);
            return View();
        }
    }
}
