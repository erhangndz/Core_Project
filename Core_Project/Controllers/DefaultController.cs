using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Core_Project.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly ISocialMediaService _socialMediaService;

        public DefaultController(IMessageService messageService, ISocialMediaService socialMediaService)
        {
            _messageService = messageService;
            _socialMediaService = socialMediaService;
        }

        public IActionResult Index()
        {

            return View();
        }

        public PartialViewResult HeaderPartial()
        {

            return PartialView();
        }

        public PartialViewResult NavbarPartial()
        {

            return PartialView();
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult SendMessage(Message p)
        {
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.Status = true;
            _messageService.TInsert(p);
           return RedirectToAction("Index");
        }

        
        public PartialViewResult SocialMediaPartial()
        {
            var values = _socialMediaService.TGetList();
            return PartialView(values);
        }
       
    }
}
