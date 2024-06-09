using WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace WebApp.Controllers
{
    public class SalaryController : Controller
    {
        private readonly IConfiguration _config;
        private readonly string _api;
        public SalaryController(IConfiguration config)
        {
            _config = config;
            _api = _config.GetValue<string>("ApiSettings:ApiUrl");
        }
        public async Task<IActionResult> Index()
        {
            List<Salary> list = new List<Salary>();
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync($"{_api}Salaries");
            if (message.IsSuccessStatusCode)
            {
                var jstring = await message.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<List<Salary>>(jstring);
                return View(list);
            }
            else
                return View(list);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.DeleteAsync($"{_api}Salaries/" + Id);
            if (message.IsSuccessStatusCode)
                return RedirectToAction("Index");
            else
                return View();

        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Salary salary)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                var jsonsalary = JsonConvert.SerializeObject(salary);
                StringContent content = new StringContent(jsonsalary, Encoding.UTF8, "application/json");
                HttpResponseMessage message = await client.PostAsync($"{_api}Salaries", content);
                if (message.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Error", "There is an API error");
                    return View(salary);

                }
            }
            else
            {
               
                return View(salary);
            }
        }
    }
}
