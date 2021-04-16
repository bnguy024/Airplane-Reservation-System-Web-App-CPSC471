using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using airplanereservationsystem.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace airplanereservationsystem.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Arrival> reservationList = new List<Arrival>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/Arrivals"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservationList = JsonConvert.DeserializeObject<List<Arrival>>(apiResponse);
                }
            }
            return View(reservationList);
        }
        public async Task<IActionResult> HomePage()
        {
            List<Departure> reservations = new List<Departure>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/Departures"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservations = JsonConvert.DeserializeObject<List<Departure>>(apiResponse);
                }
            }
            return View(reservations);
        }

        public ViewResult GetReservation() => View();

        [HttpPost]
        public async Task<IActionResult> GetReservation(int Route)
        {
            Arrival arrival = new Arrival();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/Arrivals/" + Route))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        arrival = JsonConvert.DeserializeObject<Arrival>(apiResponse);
                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;
                }
            }
            return View(arrival);
        }

        public async Task<IActionResult> ViewDepartures()
        {
            List<Departure> reservationList = new List<Departure>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/Departures"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservationList = JsonConvert.DeserializeObject<List<Departure>>(apiResponse);
                }
            }
            return View(reservationList);
        }

        public ActionResult LoginPage()
        {
            return View();
        }
    }
}
       
    

