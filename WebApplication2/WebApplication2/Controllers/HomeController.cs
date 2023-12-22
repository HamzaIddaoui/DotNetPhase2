using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly JWTService jwtService;

        public HomeController(ILogger<HomeController> logger, JWTService service)
        {
            _logger = logger;
            jwtService = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            if(username == "username" && password == "password")
            {
                // Or set a cookie with options (e.g., expiration time)
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(1), // Cookie expiration time (1 day in this example)
                    HttpOnly = true,  // Cookie is not accessible through JavaScript
                    Secure = true,    // Send cookie only over HTTPS if true
                    SameSite = SameSiteMode.None // Adjust as needed (None, Lax, Strict)
                };
                Response.Cookies.Append("JWTCookie", jwtService.GenerateJwtToken("secretKey"), cookieOptions);
                return RedirectToAction("Index");

            }
            return View();
        }
    }
}
