using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Core_Project.Controllers
{
    public class WriterUserController : Controller
    {
        private readonly IWriterService _writerService;

        public WriterUserController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult ListUser()
        {
            
            var values=JsonConvert.SerializeObject(_writerService.TGetList());
            return Json(values);
        }
        [HttpPost]
        public IActionResult AddUser(WriterUser p)
        {
            _writerService.TInsert(p);
            var values= JsonConvert.SerializeObject(p);
            return Json(values);
        }

        
    }
}
