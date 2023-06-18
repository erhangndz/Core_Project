using BusinessLayer.Concrete;
using Core_Project.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace Core_Project.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    [Authorize(Roles = "Writer")]
    public class ProfileController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public ProfileController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values= await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name=values.Name;
            model.Surname=values.Surname;
            model.ImageURL=values.ImageURL;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if(p.Image!=null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension= Path.GetExtension(p.Image.FileName);
                var imagename= Guid.NewGuid()+extension;
                var savelocation = resource + "/wwwroot/userimage/" + imagename;
                var stream= new FileStream(savelocation, FileMode.Create);
                await p.Image.CopyToAsync(stream);
                user.ImageURL= imagename;
            }
            user.Surname = p.Surname;
            user.Name = p.Name;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
            var result = await _userManager.UpdateAsync(user);
            if(result.Succeeded)
            {
                return RedirectToAction("Index","Login");
            }
            return View();
        }
    }
}
