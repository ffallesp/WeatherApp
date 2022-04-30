using LINQtoCSV;
using System;

namespace WeatherApp.Models {
    /// <summary>
    /// Clase modelo para representar un ticket. Contiene sus caracteristicas.
    /// </summary>
    [Serializable]
    public class TicketModel {
        [CsvColumn(Name="origin")]
        public string Origin { get; set; }
        [CsvColumn(Name = "destination")]
        public string Destination { get; set; }
        [CsvColumn(Name = "airline")]
        public string Airline { get; set; }
        [CsvColumn(Name = "flight_num")]
        public string Fligh_num { get; set; }
        [CsvColumn(Name = "origin_iata_code")]
        public string Ori_iata { get; set; }
        [CsvColumn(Name = "origin_name")]
        public string Ori_name { get; set; }
        [CsvColumn(Name = "origin_latitude")]
        public string Ori_lat { get; set; }
        [CsvColumn(Name = "origin_longitude")]
        public string Ori_lon { get; set; }
        [CsvColumn(Name = "destination_iata_code")]
        public string Dst_iata { get; set; }
        [CsvColumn(Name = "destination_name")]
        public string Dst_name { get; set; }
        [CsvColumn(Name = "destination_latitude")]
        public string Dst_lat { get; set; }
        [CsvColumn(Name = "destination_longitude")]
        public string Dst_lon { get; set; }
        public string Ori_weather { get; set; }
        public string Dst_weather { get; set; }
        public string Ori_weather_icon { get; set; }
        public string Dst_weather_icon { get; set; }
    }
}