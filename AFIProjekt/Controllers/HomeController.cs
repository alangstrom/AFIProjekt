using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//Request library
using System.Net;
using System.Net.Http;

namespace AFIProjekt.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            System.Diagnostics.Debug.Write("Making API Call...");
            using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
            {
                client.BaseAddress = new Uri("http://www.omdbapi.com/");
                HttpResponseMessage response = client.GetAsync("?i=tt0338013").Result;
                response.EnsureSuccessStatusCode();
                string result = response.Content.ReadAsStringAsync().Result;
                System.Diagnostics.Debug.Write("Result: " + result);
                ViewBag.Result = result;
            }
            return View();
        }

       public ActionResult LoveCalculator()
        {
            Random random = new Random();
            int love = random.Next(1, 100);
            ViewBag.loveValue = love;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}