using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ILogger<LoginController> _logger;
        private readonly string _api;

        public LoginController(IConfiguration config, ILogger<LoginController> logger)
        {
            _config = config;
            _logger = logger;
            _api = _config.GetValue<string>("ApiSettings:ApiUrl");
        }

        [HttpGet]
        public IActionResult Login()
        {
            _logger.LogInformation("Accessing Login Page");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Attempting login for user: {Username}", model.Username);
                HttpClient client = new HttpClient();
                var jsonModel = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(jsonModel, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync($"{_api}auth/login", content);

                if (response.IsSuccessStatusCode)
                {
                    var token = await response.Content.ReadAsStringAsync();
                    //HttpContext.Session.SetString("AuthToken", token);
                    _logger.LogInformation("Login successful for user: {Username}", model.Username);
                    return RedirectToAction("Index", "Person");
                }
                _logger.LogWarning("Invalid login attempt for user: {Username}", model.Username);
                ModelState.AddModelError("", "Invalid login attempt");
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("AuthToken");
            return RedirectToAction("Login");
        }
    }
}
