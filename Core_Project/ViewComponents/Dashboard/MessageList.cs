using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.ViewComponents.Dashboard
{
    public class MessageList:ViewComponent
    {
        private readonly IUserMessageService _userMessageService;

        public MessageList(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _userMessageService.TGetMessageswithUsers();
            return View(values);
        }
    }
}
