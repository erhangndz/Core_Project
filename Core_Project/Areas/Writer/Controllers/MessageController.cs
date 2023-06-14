using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Core_Project.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class MessageController : Controller
    {
        private readonly IWriterMessageService _messageService;
        private readonly UserManager<WriterUser> _userManager;

        public MessageController(IWriterMessageService messageService, UserManager<WriterUser> userManager)
        {
            _messageService = messageService;
            _userManager = userManager;
        }

       

        public async Task<IActionResult> Inbox()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var receiver = values.Email;
            var messagelist= _messageService.TGetbyFilter(x=>x.Receiver==receiver);
            return View(messagelist);
        }

        public async Task<IActionResult> Sentbox()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var sender = values.Email;
            var messagelist = _messageService.TGetbyFilter(x => x.Sender == sender);
            return View(messagelist);
        }
    }
}
