using WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WebApp.Controllers
{
    public class PersonDetailsController : Controller
    {
        private readonly IConfiguration _config;
        private readonly string _api;
        public PersonDetailsController(IConfiguration config)
        {
            _config = config;
            _api = _config.GetValue<string>("ApiSettings:ApiUrl");
        }
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync($"{_api}persondetails");
            if (message.IsSuccessStatusCode)
            {
                var jstring = await message.Content.ReadAsStringAsync();
                List<PersonDetails> list = JsonConvert.DeserializeObject<List<PersonDetails>>(jstring);
                return View(list);
            }
            else
                return View(new List<PersonDetails>());
        }

        public IActionResult Add()
        {
            PersonDetails personDetails = new PersonDetails();
            return View(personDetails);
        }

        

        [HttpPost]
        public async Task<IActionResult> Add(PersonDetails personDetails)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                var jsonPersonDetails = JsonConvert.SerializeObject(personDetails);
                StringContent content = new StringContent(jsonPersonDetails, Encoding.UTF8, "application/json");
                HttpResponseMessage message = await client.PostAsync($"{_api}persondetails", content);
                if (message.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "There is an API Error");
                    return View(personDetails);
                }

            }
            else
            {
                return View(personDetails);
            }
        }

        public async Task<IActionResult> Update(int Id)
        {
            HttpClient client = new HttpClient();

            Console.WriteLine(Id);
            Console.WriteLine($"{_api}persondetails/" + Id);

            HttpResponseMessage message = await client.GetAsync($"{_api}persondetails/" + Id);

            Console.WriteLine(Id);
            Console.WriteLine(message.IsSuccessStatusCode);
            if (message.IsSuccessStatusCode)
            {
                var jstring = await message.Content.ReadAsStringAsync();
                PersonDetails personDetails = JsonConvert.DeserializeObject<PersonDetails>(jstring);
                return View(personDetails);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(PersonDetails personDetails)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                var jsonperson = JsonConvert.SerializeObject(personDetails);
                StringContent content = new StringContent(jsonperson, Encoding.UTF8, "application/json");
                HttpResponseMessage message = await client.PutAsync($"{_api}persondetails", content);
                if (message.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(personDetails);
                }
            }
            else
            {
                return View(personDetails);
            }
        }

        public async Task<IActionResult> Delete(int Id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.DeleteAsync($"{_api}persondetails/" + Id);
            if (message.IsSuccessStatusCode)
                return RedirectToAction("Index");
            else
                return View();

        }

    }
}
