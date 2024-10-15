using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SonaHotelProject.Models;
using System.Reflection;

namespace SonaHotelProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _client;

        public HomeController()
        {
            _client = new HttpClient();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(HotelSearchViewModel model)
        {
           
                string cityId = await LocationSearch(model.name); 

                if (!string.IsNullOrEmpty(cityId))
                {

                    return RedirectToAction("Index", "Hotel", new 
                    { cityId,
                        checkInDate = model.checkinDate,
                        checkOutDate = model.checkoutDate,
                    });
                }

                return View();
            
        }

        public async Task<string> LocationSearch(string name)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=en-gb&name={name}"),
                Headers =
                {
                    { "x-rapidapi-key", "fec9d14082msh2bae643a0505c69p1c2a50jsn4b0bb9d1f16d" },
                    { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
                },
            };

            using (var response = await _client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var locations = JsonConvert.DeserializeObject<List<dynamic>>(body);

                // İlk elemanın dest_id'sini al
                return locations[0]?.dest_id; // Doğru şekilde değer alınıyor
            }
        }

    }

}

