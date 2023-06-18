using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Project.ViewComponents.Dashboard
{
    public class MessageList:ViewComponent
    {
        private readonly IMessageService _messageService;

        public MessageList(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IViewComponentResult Invoke()
        {
            var values= _messageService.TGetList().TakeLast(5).ToList();
            return View(values);
        }
    }
}
