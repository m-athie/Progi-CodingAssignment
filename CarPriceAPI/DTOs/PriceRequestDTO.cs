using CarPriceAPI.Models.Types;

namespace CarPriceAPI.DTOs
{
    public class PriceRequestDTO
    {
        public float BasePrice { get; set; }
        public VehicleTypes VehicleType { get; set; }
    }
}
