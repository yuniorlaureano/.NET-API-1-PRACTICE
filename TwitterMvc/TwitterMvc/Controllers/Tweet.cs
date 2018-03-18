using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TwitterMvc.Controllers
{
    public class Tweet
    {
         [JsonProperty("id")]
        public int Id { get; set; }
         [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
    }
}
