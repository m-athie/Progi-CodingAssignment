using CarPriceAPI.DTOs;

namespace CarPriceAPI.Services.Interfaces;
public interface IFeeCalculator
{
    List<FeeDTO> CalculateFees(PriceRequestDTO priceRequestDTO);
}
