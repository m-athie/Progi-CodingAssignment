using CarPriceAPI.DTOs;
using CarPriceAPI.Models.Types;
using CarPriceAPI.Services.Interfaces;

namespace CarPriceAPI.Services;
public class BasicBuyerFeeCalculator: IFeeCalculator
{
    public List<FeeDTO> CalculateFees(PriceRequestDTO priceRequestDTO)
    {
        var appliedFees = new List<FeeDTO>();
        float basicBuyerFee = priceRequestDTO.BasePrice * 0.10f;

        // Apply min and max restrictions to the basic buyer fee
        if (priceRequestDTO.VehicleType == VehicleTypes.Common)
        {
            basicBuyerFee = Math.Clamp(basicBuyerFee, 10.0f, 50.0f);
        }
        else if (priceRequestDTO.VehicleType == VehicleTypes.Luxury)
        {
            basicBuyerFee = Math.Clamp(basicBuyerFee, 25.0f, 200.0f);
        }

        appliedFees.Add(new FeeDTO { Name = "Basic Buyer Fee", Amount = basicBuyerFee });
        return appliedFees;
    }
}
