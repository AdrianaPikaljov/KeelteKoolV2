using Microsoft.AspNetCore.Mvc;

namespace KeelteKoolV2.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
