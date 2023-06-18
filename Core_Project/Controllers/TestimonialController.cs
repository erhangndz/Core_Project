using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IActionResult Index()
        {
            var values= _testimonialService.TGetList();
            return View(values);
        }

        public IActionResult DeleteTestimonial(int id)
        {
            var values = _testimonialService.TGetByID(id);
            _testimonialService.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateTestimonial(int id)
        {
            var values = _testimonialService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateTestimonial(Testimonial p)
        {
            _testimonialService.TUpdate(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddTestimonial()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult AddTestimonial(Testimonial p)
        {
            _testimonialService.TInsert(p);
            return RedirectToAction("Index");
        }
    }
}
