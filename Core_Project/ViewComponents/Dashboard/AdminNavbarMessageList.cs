using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Project.ViewComponents.Dashboard
{
    public class AdminNavbarMessageList:ViewComponent
    {
        private readonly IWriterMessageService _writerMessageService;
        private readonly UserManager<WriterUser> _userManager;

        public AdminNavbarMessageList(IWriterMessageService writerMessageService, UserManager<WriterUser> userManager)
        {
            _writerMessageService = writerMessageService;
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            
            
            var values = _writerMessageService.TGetbyFilter(x => x.Receiver == "admin@gmail.com").TakeLast(3).ToList();
            return View(values);
        }
    }
}
