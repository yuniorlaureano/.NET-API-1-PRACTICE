using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebApiSelfHostAplication
{
    public class HttpMsgHandler : HttpMessageHandler
    {
        protected override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            Console.WriteLine("HttpMessage Receive...");
            Task<HttpResponseMessage> message = new Task<HttpResponseMessage>(() =>
            {
                var msg = new HttpResponseMessage();
                msg.Content = new StringContent("Hola klk.....");
                var user = Thread.CurrentPrincipal.Identity.Name;
                Console.WriteLine("Message sended: " + user);

                return msg;
            });

            message.Start();
            return message;
        }
    }
}
