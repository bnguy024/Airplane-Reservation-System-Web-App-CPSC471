using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using airplanereservationsystem.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System;

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

        public ViewResult GetArrivalReservation() => View();

        [HttpPost]
        public async Task<IActionResult> GetArrivalReservation(int Route)
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
        public ViewResult AddArrivalReservation() => View();

        [HttpPost]
        public async Task<IActionResult> AddArrivalReservation(Arrival arrival)
        {
            Arrival receivedReservation = new Arrival();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(arrival), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:5001/api/Arrivals", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    receivedReservation = JsonConvert.DeserializeObject<Arrival>(apiResponse);
                }
            }
            return View(receivedReservation);
        }
        public ViewResult GetDepartureReservation() => View();

        [HttpPost]
        public async Task<IActionResult> GetDepartureReservation(int Route)
        {
            Departure departure = new Departure();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/Departures/" + Route))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        departure = JsonConvert.DeserializeObject<Departure>(apiResponse);
                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;
                }
            }
            return View(departure);
        }
    
        public ViewResult AddDepartureReservation() => View();
        [HttpPost]
        public async Task<IActionResult> AddDepartureReservation(Departure departure)
        {
            Departure receivedReservation = new Departure();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(departure), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:5001/api/Departures", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    receivedReservation = JsonConvert.DeserializeObject<Departure>(apiResponse);
                }
            }
            return View(receivedReservation);
        }

        public ViewResult LoginPage() => View();

        [HttpPost]
        public async Task<IActionResult> CustomerHome(string inputEmail, string inputPass)
        {

            Customer customer = new Customer();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/Customer/"))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        customer = JsonConvert.DeserializeObject<Customer>(apiResponse);
                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;
                }
            }

            Console.Write("Customer Email: " + customer.Email);

            if (inputEmail == "you@gmail.com" && inputPass == "password")
            {
                return View(customer);
            }
            return Redirect("LoginPage");

        }
    }
}

