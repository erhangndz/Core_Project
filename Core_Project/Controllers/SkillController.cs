using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    public class SkillController : Controller
    {
       private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        public IActionResult Index()
        {
            ViewBag.v1 = "Yetenek Listesi";
            ViewBag.v2 = "Yetenekler";
            ViewBag.v3 = "Liste";
            var values= _skillService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddSkill()
        {
            ViewBag.v1 = "Yetenek Ekleme";
            ViewBag.v2 = "Yetenekler";
            ViewBag.v3 = "Ekleme";
            return View();
        }

        [HttpPost]
        public IActionResult AddSkill(Skill p)
        {
            _skillService.TInsert(p);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSkill(int id)
        {
            var values= _skillService.TGetByID(id);
            _skillService.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateSkill(int id) 
        {
            ViewBag.v1 = "Yetenek Düzenleme";
            ViewBag.v2 = "Yetenekler";
            ViewBag.v3 = "Düzenleme";
            var values = _skillService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateSkill(Skill p)
        {
            
            _skillService.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
