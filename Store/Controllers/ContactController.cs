using Microsoft.AspNetCore.Mvc;

namespace Store.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
