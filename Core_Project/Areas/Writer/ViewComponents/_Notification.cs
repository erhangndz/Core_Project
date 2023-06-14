using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Project.Areas.Writer.ViewComponents
{
    public class _Notification:ViewComponent
    {
        private readonly IAnnouncementService _announcementService;

        public _Notification(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IViewComponentResult Invoke()
        {
            var values= _announcementService.TGetList().TakeLast(5).ToList();
            return View(values);
        }
    }
}
