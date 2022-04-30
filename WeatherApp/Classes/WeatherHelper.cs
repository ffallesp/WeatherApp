using LINQtoCSV;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Classes {
    /// <summary>
    /// Clase auxiliar para conectar el controlador con las funciones para consumir la API OpenWeatherMap y extraer los datos del archivo csv.
    /// </summary>
    public class WeatherHelper {
        private OpenWeatherAPI api = new OpenWeatherAPI();

        /// <summary>
        /// Método para consultar los datos del archivo. Los convierte a una lista del tipo TicketModel.
        /// Puede ser filtrada o no.
        /// </summary>
        /// <param name="path">Ruta del archivo, este siempre debe estar en la carpeta raiz del proyecto.</param>
        /// <param name="fligh_num">Si esta vartiable contiene algo se usa para filtrar los resultados.</param>
        /// <returns>Lista de los tickets.</returns>
        public List<TicketModel> RetrieveData(string path, string fligh_num = "") {
            var csvDesc = new CsvFileDescription {
                FirstLineHasColumnNames = true,
                IgnoreUnknownColumns = true,
                SeparatorChar = ',',
                UseFieldIndexForReadingData = false
            };
            var csvContext = new CsvContext();
            var records = csvContext.Read<TicketModel>(path, csvDesc);
            if (fligh_num != "") {
                return records.Where(x => x.Fligh_num.Contains(fligh_num)).ToList();
            } 
            return records.ToList();
        }

        /// <summary>
        /// Método para consultar a la API el clima dependiendo de latitud y longitud contenidos en el modelo recibido
        /// tanto de origen como de destino.
        /// </summary>
        /// <param name="ticket">Modelo que contiene latitud y longitud.</param>
        /// <param name="lang">Parametro para determinar el idioma de los resultados obtenidos.</param>
        /// <returns></returns>
        public async Task GetWeatherAsync(TicketModel ticket, string lang) {
            var json_ori = await api.GetWeather(ticket.Ori_lat, ticket.Ori_lon, lang);
            var json_dst = await api.GetWeather(ticket.Dst_lat, ticket.Dst_lon, lang);
            ResponseWeatherModel response1 = JsonConvert.DeserializeObject<ResponseWeatherModel>(json_ori);
            ResponseWeatherModel response2 = JsonConvert.DeserializeObject<ResponseWeatherModel>(json_dst);
            ticket.Ori_weather = response1.weather[0].main;
            ticket.Ori_weather_icon = response1.weather[0].icon;
            ticket.Dst_weather = response2.weather[0].main;
            ticket.Dst_weather_icon = response2.weather[0].icon;
        }

        /// <summary>
        /// Método para obtener el clima de un ticket y devolver los response directo de la consulta.
        /// </summary>
        /// <param name="ticket">Modelo que contiene latitud y longitud.</param>
        /// <param name="lang">Parametro para determinar el idioma de los resultados obtenidos.</param>
        /// <returns>Arreglod de response, el primer elemento son los datos del clima de origen, y el segundo es de destino.</returns>
        public async Task<ResponseWeatherModel[]> GetWeatherIndividual(TicketModel ticket, string lang) {
            var json = await api.GetWeather(ticket.Ori_lat, ticket.Ori_lon, lang);
            var json2 = await api.GetWeather(ticket.Dst_lat, ticket.Dst_lon, lang);
            ResponseWeatherModel response = JsonConvert.DeserializeObject<ResponseWeatherModel>(json);
            ResponseWeatherModel response2 = JsonConvert.DeserializeObject<ResponseWeatherModel>(json2);
            return new[] { response, response2};
        }
    }
}