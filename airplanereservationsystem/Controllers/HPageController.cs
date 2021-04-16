using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using airplanereservationsystem.Models;
using System.Net.Http;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace airplanereservationsystem.Controllers
{
    public class HPageController : Controller
    {
        public async Task<IActionResult> HomePage()
        {
            List<Departure> reservation = new List<Departure>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/Departures"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservation = JsonConvert.DeserializeObject<List<Departure>>(apiResponse);
                }
            }
            return View(reservation);
        }
    }
}
