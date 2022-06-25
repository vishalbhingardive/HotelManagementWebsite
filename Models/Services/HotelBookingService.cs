using Newtonsoft.Json;

namespace HotelManagementWebsite.Models.Services
{
    public class HotelBookingService : IHotelBooking
    {
        private readonly HttpClient _httpClient;

        public HotelBookingService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task<HotelSearchViewModel> GetAll(string name, string hotelName, int perDayCost)
        {
            var hotelSearchViewModel = new HotelSearchViewModel();

            var uriBooking = $"https://localhost:7047/api/Hotels/{name}/{hotelName}/{perDayCost}";
            var responseText = await _httpClient.GetStringAsync(uriBooking);
            hotelSearchViewModel.HotelList = JsonConvert.DeserializeObject<List<HotelViewModel>>(responseText);

            if (hotelName != null)
            {
                var uriReturn = $"https://localhost:7081/api/Flights/{name}/{hotelName}/{perDayCost}";
                var responseTextReturn = await _httpClient.GetStringAsync(uriReturn);
                hotelSearchViewModel.HotelList = JsonConvert.DeserializeObject<List<HotelViewModel>>(responseTextReturn);
            }

            return hotelSearchViewModel;
           
        }
    }
}
