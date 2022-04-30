using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using WeatherApp.Models;
using PagedList;
using System.Net;
using WeatherApp.Classes;

namespace WeatherApp.Controllers {
    public class HomeController : Controller {
        private WeatherHelper Weather = new WeatherHelper();

        /// <summary>
        /// Funcion principal, consulta los registros y los envia a la vista.
        /// </summary>
        /// <param name="searchString"></param>
        /// <param name="page"></param>
        /// <param name="currentFilter"></param>
        /// <returns>Lista de tickets</returns>
        public async Task<ActionResult> Index(string searchString, int? page, string currentFilter = "") {
            if (searchString != null) {
                page = 1;
            } else {
                searchString = currentFilter; 
            }
            int pageSize = 7;
            int pageNumber = (page ?? 1);
            ViewBag.CurrentFilter = searchString;
            List<TicketModel> records = new List<TicketModel>();
            try {
                records = Weather.RetrieveData(Server.MapPath("./") + "challenge_dataset.csv", searchString);
                IPagedList<TicketModel> listaTickets = records.ToPagedList(pageNumber, pageSize);
                for (int i = 0; i < listaTickets.Count; i++) {
                    await Weather.GetWeatherAsync(listaTickets[i], "en");
                }
                ViewBag.RetrieveWeatherError = false;
            } catch(FileNotFoundException ex) {
                ViewBag.RetrieveWeatherError = true;
                ViewBag.MessageError = ex.Message;
            } catch (WebException ex) {
                ViewBag.RetrieveWeatherError = true;
                ViewBag.MessageError = ex.Message;
            } catch (HttpRequestException ex) {
                ViewBag.RetrieveWeatherError = true;
                ViewBag.MessageError = ex.Message;
            }
            return View(records.ToPagedList(pageNumber, pageSize));
        }
        /// <summary>
        /// Método para mostrar los detalles de un solo ticket. Vuelve a consultar todos los datos
        /// de clima.
        /// </summary>
        /// <param name="ticket">Ticket a consultar</param>
        /// <returns>Modelo de datos para mostrar en la vista.</returns>
        public async Task<ActionResult> Details(TicketModel ticket) {
            WeatherDetailsModel result = new WeatherDetailsModel();
            result.Ticket = ticket;
            try {
                var res = await Weather.GetWeatherIndividual(ticket, "en");
                result.Weather_ori = res[0];
                result.Weather_dst = res[1];
                ViewBag.RetrieveWeatherError = false;
            } catch (WebException ex) {
                ViewBag.RetrieveWeatherError = true;
                ViewBag.MessageError = ex.Message;
            } catch (HttpRequestException ex) {
                ViewBag.RetrieveWeatherError = true;
                ViewBag.MessageError = ex.Message;
            }
            return View(result);
        }
    }
}