namespace WeatherApp.Models {
    /// <summary>
    /// Clase modelo para almacenar un ticket y sus datos climatologicos de origen y destino.
    /// </summary>
    public class WeatherDetailsModel {
        public TicketModel Ticket { get; set; }
        public ResponseWeatherModel Weather_ori { get; set; }
        public ResponseWeatherModel Weather_dst { get; set; }
    }
}