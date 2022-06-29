
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OptionPatternTask.Models;

namespace OptionPatternTask.Controllers
{
    [AllowAnonymous]
    public class OptionPatternTaskController : Controller
    {
        private readonly TitleConfiguration _homePageTitleConfiguration;
        public OptionPatternTaskController(IOptions<TitleConfiguration> homePageTitleConfiguration)
        {
            _homePageTitleConfiguration = homePageTitleConfiguration.Value;
        }
        public IActionResult Index()
        {
            var homeModel = new HomeModel
            {
                Configuration = _homePageTitleConfiguration
            };
            return View(homeModel);
        }
    }
}
