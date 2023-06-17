using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Project.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Message")]
    public class MessageController : Controller
    {
        private readonly IWriterMessageService _messageService;
        private readonly UserManager<WriterUser> _userManager;

        public MessageController(IWriterMessageService messageService, UserManager<WriterUser> userManager)
        {
            _messageService = messageService;
            _userManager = userManager;
        }


        [Route("")]
        [Route("Inbox")]
        public async Task<IActionResult> Inbox()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var receiver = values.Email;
            var messagelist= _messageService.TGetbyFilter(x=>x.Receiver==receiver);
            return View(messagelist);
        }
        [Route("")]
        [Route("Sentbox")]
        public async Task<IActionResult> Sentbox()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var sender = values.Email;
            var messagelist = _messageService.TGetbyFilter(x => x.Sender == sender);
            return View(messagelist);
        }
        [Route("MessageDetails/{id}")]
        public IActionResult MessageDetails(int id)
        {
            var values= _messageService.TGetByID(id);
            return View(values);
        }
        [Route("SentMessageDetails/{id}")]
        public IActionResult SentMessageDetails(int id)
        {
            var values = _messageService.TGetByID(id);
            return View(values);
        }

        [HttpGet]
        [Route("")]
        [Route("AddMessage")]
        public IActionResult AddMessage()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        [Route("AddMessage")]
        public async Task<IActionResult> AddMessage(WriterMessage p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p.Sender = values.Email;
            p.SenderName = values.Name +" " + values.Surname;
            Context c = new Context();
            var receivername= c.Users.Where(x=>x.Email==p.Receiver).Select(x=>x.Name + " " + x.Surname).FirstOrDefault();
            p.Date=DateTime.Parse(DateTime.Now.ToShortDateString());
            p.ReceiverName= receivername;
            _messageService.TInsert(p);
            return RedirectToAction("Sentbox");
        }
    }
}
