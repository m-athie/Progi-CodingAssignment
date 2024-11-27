using CarPriceAPI.DTOs;

namespace CarPriceAPI.Services.Interfaces
{
    public interface IPricesService
    {
        PriceResponseDTO CalculatePrice(PriceRequestDTO priceRequestDTO);
    }
}
