using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WeatherApp.Models {
    /// <summary>
    /// Clase Modelo para almacenar la respuesta de la API OpenWeatherMap
    /// </summary>
    public class ResponseWeatherModel {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        [JsonPropertyName("base")]
        public string _base { get; set; }
        public Main main { get; set; }
        public string visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public string dt { get; set; }
        public Sys sys { get; set; }
        public string timezone { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string cod { get; set; }
    }

    public class Coord {
        public string lon { get; set; }
        public string lat { get; set; }
    }

    public class Weather {
        public string id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Main {
        public string temp { get; set; }
        public string feels_like { get; set; }
        public string temp_min { get; set; }
        public string temp_max { get; set; }
        public string pressure { get; set; }
        public string humidity { get; set; }
    }

    public class Wind {
        public string deg { get; set; }
        public string speed { get; set; }
    }

    public class Clouds {
        public string all { get; set; }
    }

    public class Sys {
        public string type { get; set; }
        public string id { get; set; }
        public string message { get; set; }
        public string country { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }
    }
}