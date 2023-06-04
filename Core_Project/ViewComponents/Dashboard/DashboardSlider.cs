using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.ViewComponents.Dashboard
{
    public class DashboardSlider:ViewComponent
    {
        private readonly IPortfolioService _portfolioService;

        public DashboardSlider(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public IViewComponentResult Invoke()
        {
            var values= _portfolioService.TGetList();
            return View(values);
        }
    }
}
