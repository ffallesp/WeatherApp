using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherApp.Classes {
    /// <summary>
    /// Clase para consumir la api OpenWeatherMap
    /// </summary>
    public class OpenWeatherAPI {
        /// <summary>
        /// Variable que almacena la clave unica para consumir la API
        /// </summary>
        private readonly string API_key = "717edcd0f12ee5953f5528b0fe4e6cd4";
        /// <summary>
        /// EndPoint de la API
        /// </summary>
        private readonly string API_url = "https://api.openweathermap.org/data/2.5/weather";
        private HttpClient Client = new HttpClient();
        
        /// <summary>
        /// consume la API obteniendo los resultados climatologicos en base a la latitud y longitud.
        /// </summary>
        /// <param name="lat">Latidud</param>
        /// <param name="lon">Longitud</param>
        /// <param name="lang">Idioma requerido</param>
        /// <returns>Json en texto plano.</returns>
        public async Task<string> GetWeather(string lat, string lon,string lang) {
            var uri = QueryHelpers.AddQueryString(API_url, GetUri(lat, lon, lang));
            var json = await Client.GetStringAsync(uri);
            return json;
        }

        /// <summary>
        /// Método auxiliar para crear la URI de consulta que se envia a la API.
        /// </summary>
        /// <param name="lat">Latitud</param>
        /// <param name="lon">Longitud</param>
        /// <param name="lang">Idioma requerido</param>
        /// <returns>URI construida.</returns>
        public Dictionary<string, string> GetUri(string lat, string lon, string lang) {
            var request = new Dictionary<string, string>() {
                ["lat"] = lat,
                ["lon"] = lon,
                ["appid"] = API_key,
                ["lang"] = lang
            };
            return request;
        }
    }
}