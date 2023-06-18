using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SkillController : Controller
    {
       private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        public IActionResult Index()
        {
           
            var values= _skillService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddSkill()
        {
           
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
