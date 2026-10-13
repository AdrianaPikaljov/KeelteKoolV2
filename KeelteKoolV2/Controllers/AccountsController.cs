using KeelteKoolV2.Core.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KeelteKoolV2.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<ApplicationUser> _
        public IActionResult Index()
        {
            return View();
        }
    }
}
