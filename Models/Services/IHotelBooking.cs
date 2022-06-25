namespace HotelManagementWebsite.Models.Services
{
    public interface IHotelBooking
    {
        Task<HotelSearchViewModel> GetAll(string name, string hotelName, int perDayCost);
    }
}
