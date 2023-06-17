using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMessageService _messageService;

        public ContactController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult Index()
        {
            var values = _messageService.TGetList();
            return View(values);
        }

        public IActionResult DeleteContact(int id)
        {
            var values= _messageService.TGetByID(id);
            _messageService.TDelete(values);
            return RedirectToAction("Index");

        }

        public IActionResult ContactDetails(int id)
        {
            var values = _messageService.TGetByID(id);
            return View(values);
        }
    }
}