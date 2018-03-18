using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.SelfHost;
using System.Web.Http;
using System.Net.Http;

namespace WebApiSelfHostAplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var configuration = new HttpSelfHostConfiguration("http://localhost:8999");
            var configuration = new MyConfig("http://localhost:8999");
            var server = new HttpSelfHostServer(configuration, new HttpMsgHandler());
            //configuration.Routes.MapHttpRoute("default", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            //var server = new HttpSelfHostServer(configuration);
            var task = server.OpenAsync();
            task.Wait();
            Console.WriteLine("Up and running....");
            Console.ReadKey();
            //Console.WriteLine("Press enter to enter the client");

            //var client = new HttpClient();
            //client.GetAsync("http://localhost:8999/api/my/").ContinueWith((t) => {

            //    HttpResponseMessage result = t.Result;
            //    result.Content.ReadAsStringAsync().ContinueWith((rt)=>{

            //        Console.WriteLine(" THE RESPONSES IS: "+rt.Result);
            //    });
            //});
            //Console.ReadKey();
        }
    }
}
