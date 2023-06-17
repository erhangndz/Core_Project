using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    public class ExperienceController : Controller
    {
        IExperienceService _experienceService;

        public ExperienceController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        public IActionResult Index()
        {
           
            var values= _experienceService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddExperience()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult AddExperience(Experience p)
        {
            _experienceService.TInsert(p);
            return RedirectToAction("Index");
        }


        public IActionResult DeleteExperience(int id)
        {
            var values = _experienceService.TGetByID(id);
            _experienceService.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateExperience(int id)
        {
            
            var values = _experienceService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateExperience(Experience p)
        {

            _experienceService.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
