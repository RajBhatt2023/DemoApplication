using Dummy.WebApplication.Models;
using DummyProject.Service.IServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dummy.WebApplication.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
         private readonly IEmailService _emailService;

        public HomeController(ILogger<HomeController> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> LogOut()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Email(string toEmail, string subject, string body) 
        {
            try
            {
                // Call the SendEmailAsync method from the injected service
                await _emailService.SendEmailAsync(toEmail, subject, body);

                // Email sent successfully, you can add your success logic here
                ViewBag.Message = "Email sent successfully!";
                return View("Index");
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, etc.
                ViewBag.Error = $"Error sending email: {ex.Message}";
                return View("Index");
            }
        }
    }
}