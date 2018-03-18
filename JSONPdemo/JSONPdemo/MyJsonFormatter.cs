using JSONPdemo.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace JSONPdemo
{
    public class MyJsonFormatter : MediaTypeFormatter
    {
        public MyJsonFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/javascript"));
        }

        public override System.Threading.Tasks.Task WriteToStreamAsync(Type type, object value, System.IO.Stream writeStream, System.Net.Http.HttpContent content, System.Net.TransportContext transportContext)
        {

            return Task.Factory.StartNew(() => {

                var jsonp = (JSONPreturn)value;
                var sw = new StreamWriter(writeStream, UTF8Encoding.Default);
                sw.Write("{0}({1});", jsonp.Callback, jsonp.JSON);
                sw.Flush();
            });
        }

        public override bool CanWriteType(Type type)
        {
            return type == (typeof(JSONPreturn));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }
    }
}
