using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.ViewComponents.Contact
{
    public class ContactInfo:ViewComponent
    {
        private readonly IContactInfoService _contactInfoService;

        public ContactInfo(IContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _contactInfoService.TGetList();
            return View(values);
        }
    }
}
