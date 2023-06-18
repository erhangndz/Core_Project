using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core_Project.Controllers
{
    public class Experience2Controller : Controller
    {
        private readonly IExperienceService _experienceService;

        public Experience2Controller(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListExperience()
        {

            var values = JsonConvert.SerializeObject(_experienceService.TGetList());
            return Json(values);
        }
        [HttpPost]
        public IActionResult AddExperience(Experience p)
        {
            _experienceService.TInsert(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }

        public IActionResult GetByID(int ExperienceID)
        {
            var values= _experienceService.TGetByID(ExperienceID);
            var result= JsonConvert.SerializeObject(values);
            return Json(result);
        }

        public IActionResult DeleteExperience(int id)
        {
            var values = _experienceService.TGetByID(id);
            _experienceService.TDelete(values);
            return Ok();
        }

        [HttpPost]
        public IActionResult UpdateExperience(int id, string name, string date)
        {
            var findvalue = _experienceService.TGetByID(id);

            if (findvalue != null)
            {
                findvalue.Name = name;
                findvalue.Date = date;
                _experienceService.TUpdate(findvalue);
                var val = JsonConvert.SerializeObject(findvalue);

                return Json(val);
            }
            return NoContent();
        }
    }
}
