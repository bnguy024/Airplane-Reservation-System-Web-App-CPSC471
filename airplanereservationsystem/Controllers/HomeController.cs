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
    }
}
