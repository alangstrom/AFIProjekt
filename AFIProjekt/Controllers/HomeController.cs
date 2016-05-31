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
            
            return View();
        }

       public ActionResult LoveCalculator()
        {

            AFIProjektEntities1 db = new AFIProjektEntities1();
            Random random = new Random();
            int love = random.Next(1, 100);
            int movieid = random.Next(0, 10);

            ViewBag.loveValue = love;
            System.Diagnostics.Debug.Write("Making API Call...");
            using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
            {
                client.BaseAddress = new Uri("http://www.omdbapi.com/");
                HttpResponseMessage response = client.GetAsync("?i=tt0338013").Result;
                response.EnsureSuccessStatusCode();
                string result = response.Content.ReadAsStringAsync().Result;
                System.Diagnostics.Debug.Write("Result: " + result);
                dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
                ViewBag.Movietitle = (string)json.Title;
                ViewBag.Poster = (string)json.Poster;
                ViewBag.Plot = (string)json.Plot;
                ViewBag.Rating = (string)json.imdbRating;
                ViewBag.Result = result;
            }
            return View("Love");
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