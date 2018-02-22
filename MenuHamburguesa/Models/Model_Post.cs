using System;
using Newtonsoft.Json;

namespace MenuHamburguesa.Models
{
    public class Model_Post
    {

        [JsonProperty("id")]
       public int Id { get; set; }

        [JsonProperty("title")]
        public string Title{ get; set; } 
    }
}
