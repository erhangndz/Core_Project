using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Project.ViewComponents.Dashboard
{
    public class Last5Projects:ViewComponent
    {
        private readonly IPortfolioService _portfolioService;

        public Last5Projects(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public IViewComponentResult Invoke()
        {
            var values= _portfolioService.TGetList().TakeLast(5).ToList();
            return View(values);
        }
    }
}
