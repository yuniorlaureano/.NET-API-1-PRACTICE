using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DefaultApi.Controllers
{
    public class ValuesController : ApiController
    {
        static List<string> data = initList();

        private static List<string> initList()
        {
            var ret = new List<string>() { "value1", "value2" };
            return ret;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return data;
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            if (id > data.Count)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent, "Not item selected");
            }

            return Request.CreateResponse(HttpStatusCode.OK, data); 
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]string value)
        {
            data.Add(value);
            var message = Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location = new Uri(Request.RequestUri + (data.Count - 1).ToString());
            return message;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            data[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            data.RemoveAt(id);
        }
    }
}
