using BusinessLayer.Abstract;
using DataAccessLayer.Migrations;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.ViewComponents.SocialMedia
{
    public class SocialMediaList:ViewComponent
    {
        private readonly ISocialMediaService _socialMediaService;

        public SocialMediaList(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        public IViewComponentResult Invoke()
        {
            var values= _socialMediaService.TGetList();
            return View(values);
        }
    }
}
