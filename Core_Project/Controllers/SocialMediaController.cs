using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaService _socialmediaservice;

        public SocialMediaController(ISocialMediaService socialmediaservice)
        {
            _socialmediaservice = socialmediaservice;
        }

        public IActionResult Index()
        {
            var values = _socialmediaservice.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddSocialMedia()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia p)
        {
            p.Status = true;
            _socialmediaservice.TInsert(p);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSocialMedia(int id)
        {
            var values = _socialmediaservice.TGetByID(id);
            _socialmediaservice.TDelete(values);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            var values = _socialmediaservice.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateSocialMedia(SocialMedia p)
        {
            p.Status = true;
            _socialmediaservice.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
