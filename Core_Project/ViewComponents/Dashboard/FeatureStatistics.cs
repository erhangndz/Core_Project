using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Project.ViewComponents.Dashboard
{
    public class FeatureStatistics:ViewComponent
    {
        Context c= new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.skillnumber = c.Skills.Count();
            ViewBag.unreadmessage = c.Messages.Count();
            ViewBag.testimonial= c.Testimonials.Count();
            ViewBag.experiencenumber = c.Experiences.Count();
            return View();
        }
    }
}
