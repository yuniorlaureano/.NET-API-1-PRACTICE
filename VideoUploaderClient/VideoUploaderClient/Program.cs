using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.IO;
using System.Net.Http;

namespace VideoUploaderClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var stram = File.Open("Video_1518716082.wmv", FileMode.Open);
            var content = new MultipartFormDataContent();
            content.Add(new StreamContent(stram), "\"file\"","\"video.wmv\"");

            var task = client.PostAsync("http://localhost:56493/Vide/upload", content).ContinueWith((response) =>
            {

                response.Result.EnsureSuccessStatusCode();
            }).ContinueWith((err) => {

                if (err.Exception != null)
                {
                    Console.WriteLine("Exception: " + err.Exception.ToString() );
                }
            });

            task.Wait();
            Console.WriteLine("Video uploaded");
        }
    }
}
