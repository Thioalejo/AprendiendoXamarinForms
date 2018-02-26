using System;
using Newtonsoft.Json;

namespace MenuHamburguesa.Models
{
    public class Personajes
    {
        [JsonProperty("Equipo")]
        public string Equipo
        {
            get;
            set;
        }

        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty("image")]
        public string Imagen
        {
            get;
            set;
        }
    }
}
