using KeelteKoolV2.Core.ServiceInterface;
using KeelteKoolV2.Data;
using Microsoft.AspNetCore.Mvc;

namespace KeelteKoolV2.Controllers
{
    public class LanguageCoursesController : Controller
    {

        private readonly KeelteKoolV2Context _context;

        private readonly ILanguageCoursesServices _languageCoursesServices;

        public LanguageCoursesController(KeelteKoolV2Context context, ILanguageCoursesServices languageCoursesServices)
        {
            _context = context;
            _languageCoursesServices = languageCoursesServices;
        }


        public IActionResult Index()
        {
            return View();
        //need to get all, not under test rn 
        }

        [HttpGet]
        public IActionResult Create()
        {
            LanguageCourseViewModel vm = new();
            return View(vm);
        }
    }
}
