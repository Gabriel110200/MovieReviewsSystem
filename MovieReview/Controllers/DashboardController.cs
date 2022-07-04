using Microsoft.AspNetCore.Mvc;

namespace MovieReview.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
