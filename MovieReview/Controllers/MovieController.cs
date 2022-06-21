using Microsoft.AspNetCore.Mvc;

namespace MovieReview.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
