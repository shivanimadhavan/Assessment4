using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WeatherMVC.Models;

namespace WeatherMVC.Controllers
{
    public class ClimateClientController : Controller
    {
        // GET: WeatherController
        public async Task<ActionResult> Index()
        {
            string Baseurl = "http://localhost:55139/";
            var ProdInfo = new List<WeatherClient>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/WeatherDetails");
                if (Res.IsSuccessStatusCode)
                {
                    var ProdResponse = Res.Content.ReadAsStringAsync().Result;
                    ProdInfo = JsonConvert.DeserializeObject<List<WeatherClient>>(ProdResponse);
                }
                return View(ProdInfo);
            }
        }

        // GET: WeatherController/Details/5
        public async Task<ActionResult> Details(string City)
        {
            TempData["City"] = City;
            string city = Convert.ToString(TempData["City"]);
            WeatherClient b = new WeatherClient();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:55139/api/ClimateDetails/" + city))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    b = JsonConvert.DeserializeObject<WeatherClient>(apiResponse);
                }
            }
            return View(b);
        }

        // GET: WeatherController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(WeatherClient b)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(b), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:55139/api/ClimateDetails/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<WeatherClient>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(string City)
        {
            TempData["City"] = City;
            WeatherClient b = new WeatherClient();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:55139/api/ClimateDetails/" + City))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    b = JsonConvert.DeserializeObject<WeatherClient>(apiResponse);
                }
            }
            return View(b);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(WeatherClient b)
        {
            string city = Convert.ToString(TempData["City"]);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:55139/api/ClimateDetails/" + city))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                }
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(string City)
        {
            TempData["City"] = City;
            WeatherClient b = new WeatherClient();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:55139/api/ClimateDetails/" + City))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    b = JsonConvert.DeserializeObject<WeatherClient>(apiResponse);
                }
            }
            return View(b);
        }
        [HttpPost]

        public async Task<ActionResult> Edit(WeatherClient b)
        {

            string city = Convert.ToString(TempData["City"]);
            using (var httpClient = new HttpClient())
            {
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(b), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("http://localhost:55139/api/ClimateDetails/" + city, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    b = JsonConvert.DeserializeObject<WeatherClient>(apiResponse);

                }
            }
            return RedirectToAction("Index");
        }
    }
}