using Dummy.WebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.WebApplication.Controllers
{
        [Authorize]
        public class DealerProfile : Controller
        {
            public IActionResult Index()
            {
                return View();
            }
            public ActionResult DealerProfileForm(DealerProfileRequestM dealerProfileRequestM)  
            {
                return View();
            }
        }
}
