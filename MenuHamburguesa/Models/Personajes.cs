using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MenuHamburguesa.Models
{
    public class Habilidades
    {
        public string Fuerza { get; set; }
        public string Espiritu { get; set; }
        public string Fortaleza { get; set; }
    }

    public class Personaje
    {
        public string Equipo { get; set; }
        public string name { get; set; }
        public string Especialidad { get; set; }
        public string image { get; set; }
        public Habilidades Habilidades { get; set; }
    }

    public class RootObject
    {
        public List<Personaje> Personajes { get; set; }
    }
}
