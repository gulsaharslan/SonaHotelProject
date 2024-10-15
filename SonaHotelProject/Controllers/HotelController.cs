using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SonaHotelProject.Models;
using System.Net.Http.Headers;

namespace SonaHotelProject.Controllers
{
    public class HotelController : Controller
    {
        public async Task<IActionResult> Index(string cityId, string checkInDate, string checkOutDate)
        {

            DateTime checkIn = DateTime.Parse(checkInDate);
            DateTime checkOut = DateTime.Parse(checkOutDate);

            // API'nin beklediği formata dönüştür
            string formattedCheckInDate = checkIn.ToString("yyyy-MM-dd");
            string formattedCheckOutDate = checkOut.ToString("yyyy-MM-dd");
          
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v2/hotels/search?dest_id={cityId}&order_by=popularity&checkout_date={formattedCheckOutDate}&children_number=2&filter_by_currency=EUR&locale=en-gb&dest_type=city&checkin_date={formattedCheckInDate}&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&children_ages=5%2C0&include_adjacency=true&page_number=0&adults_number=2&room_number=1&units=metric"),
                Headers =
                        {
                            { "x-rapidapi-key", "fec9d14082msh2bae643a0505c69p1c2a50jsn4b0bb9d1f16d" },
                            { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
                        },
                                };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<HotelListViewModel>(body);
                return View(values.results.ToList());
            }
        }

        [HttpGet("/Hotel/HotelDetail/{hotel_id}")]
        public async Task<IActionResult> HotelDetail(int hotel_id)
        {
            int hotelId = hotel_id;
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/data?hotel_id={hotel_id.ToString()}&locale=en-gb"),
                Headers =
                {
                    { "x-rapidapi-key", "fec9d14082msh2bae643a0505c69p1c2a50jsn4b0bb9d1f16d" },
                    { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<HotelDetailViewModel>(body);
                return View(values);
            }
        }
    }
}