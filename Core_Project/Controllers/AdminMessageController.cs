using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Core_Project.Controllers
{
    public class AdminMessageController : Controller
    {
        private readonly IWriterMessageService _writermessageService;

        public AdminMessageController(IWriterMessageService writermessageService)
        {
            _writermessageService = writermessageService;
        }

        public IActionResult Inbox()
        {
            var values = _writermessageService.TGetbyFilter(x => x.Receiver == "admin@gmail.com");
            return View(values);
        }

        public IActionResult Sentbox()
        {
            var values = _writermessageService.TGetbyFilter(x => x.Sender == "admin@gmail.com");
            return View(values);
        }

        public IActionResult MessageDetails(int id)
        {
            var values = _writermessageService.TGetByID(id);
            return View(values);
        }

        public IActionResult SentMessageDetails(int id) 
        { 
        var values= _writermessageService.TGetByID(id);
            return View(values);
        }

        public IActionResult DeleteMessage(int id,string sourcePage)
        {
            var values = _writermessageService.TGetByID(id);
            _writermessageService.TDelete(values);
            if (sourcePage == "Inbox")
            {
                return RedirectToAction("Inbox");
            }
            else if (sourcePage == "Sentbox")
            {
                return RedirectToAction("Sentbox");
            }
            else
            {
                return RedirectToAction("Inbox");
            }
           
        }
        [HttpGet]
        public IActionResult AddMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMessage(WriterMessage p)
        {
            p.Sender = "admin@gmail.com";
            p.Date=DateTime.Parse(DateTime.Now.ToShortDateString());
            p.SenderName = "Admin";
            Context c = new Context();
            var receivername = c.Users.Where(x => x.Email == p.Receiver).Select(x => x.Name + " " + x.Surname).FirstOrDefault();
            p.ReceiverName=receivername;
            _writermessageService.TInsert(p);
            return RedirectToAction("Sentbox");
        }
    }
}
