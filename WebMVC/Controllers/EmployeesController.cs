using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shared.Entities;

using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net.Http.Formatting;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class EmployeesController : Controller
    {
    

        public async Task<ActionResult> Index()
        {
            
            HttpClient client;
            //The URL of the WEB API Service
            string url = "http://localhost:55713/api/Service";

            client = new HttpClient();
            client.BaseAddress = new Uri(url);
           
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Employees = JsonConvert.DeserializeObject<List<FullTimeEmployee>>(responseData);

                return View(Employees);
            }
            return View("Error");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(EmployeePOCO Emp)
        {
            
            HttpClient client;
            //The URL of the WEB API Service
            string url = "http://localhost:55713/api/Services";

            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            //client.DefaultRequestHeaders.Accept.Clear();
           // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

          

            HttpResponseMessage responseMessage =  client.PostAsJsonAsync("", Emp).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }

    }

}


