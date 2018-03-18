using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TwitterMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Tweet> model = null;
            //"http://search.twitter.com/search.json?q=pluralsight"
            var cliente = new HttpClient();
            var task = cliente.GetAsync("https://jsonplaceholder.typicode.com/posts").ContinueWith((_response) =>
            {

                HttpResponseMessage response = _response.Result;
                var readTask = response.Content.ReadAsStringAsync();
                model = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Tweet>>(readTask.Result);
                

            
            });

            task.Wait();

            return View(model);
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