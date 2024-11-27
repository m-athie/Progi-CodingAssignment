using CarPriceAPI.DTOs;
using CarPriceAPI.Models.Types;
using CarPriceAPI.Services.Interfaces;

namespace CarPriceAPI.Services
{
    public class PricesService : IPricesService
    {
        /// <summary>
        /// Calculates the total price based on the provided <paramref name="priceRequestDTO"/>.
        /// It calculates various fees (basic buyer fee, seller's special fee, association fee, and storage fee),
        /// adds them to the base price, and returns the total price.
        /// </summary>
        /// <param name="priceRequestDTO">The request DTO containing the base price and vehicle type.</param>
        /// <returns>A <see cref="PriceResponseDTO"/> containing the total price and the applied fees.</returns>
        public PriceResponseDTO CalculatePrice(PriceRequestDTO priceRequestDTO)
        {
            // Initialize a list to store the fees
            var appliedFees = new List<FeeDTO>();

            // Calculate the basic buyer fee
            var basicBuyerFee = CalculateBasicBuyerFee(priceRequestDTO);
            appliedFees.Add(basicBuyerFee);

            // Calculate the seller's special fee
            var sellersSpecialFee = CalculateSellersFee(priceRequestDTO);
            appliedFees.Add(sellersSpecialFee);

            // Calculate the association fee
            var associationFee = CalculateAssociationFee(priceRequestDTO);
            appliedFees.Add(associationFee);

            // Calculate the fixed storage fee
            var storageFee = CalculateStorageFee(priceRequestDTO);
            appliedFees.Add(storageFee);

            // Calculate the total price
            float totalPrice = priceRequestDTO.BasePrice + basicBuyerFee.Amount + sellersSpecialFee.Amount + associationFee.Amount + storageFee.Amount;

            // Return the result as a PriceResponseDTO
            return new PriceResponseDTO
            {
                TotalPrice = totalPrice,
                AppliedFees = appliedFees
            };
        }

        /// <summary>
        /// Calculates the basic buyer fee based on the vehicle type and the base price.
        /// The fee is clamped within a range depending on the vehicle type.
        /// </summary>
        /// <param name="priceRequestDTO">The request DTO containing the base price and vehicle type.</param>
        /// <returns>A <see cref="FeeDTO"/> representing the basic buyer fee with the calculated amount.</returns>
        private FeeDTO CalculateBasicBuyerFee(PriceRequestDTO priceRequestDTO)
        {
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

            return new FeeDTO { Name = "Basic Buyer Fee", Amount = basicBuyerFee };
        }

        /// <summary>
        /// Calculates the seller's special fee based on the vehicle type.
        /// For common vehicles, the fee is 2% of the base price, and for luxury vehicles, it is 4%.
        /// </summary>
        /// <param name="priceRequestDTO">The request DTO containing the base price and vehicle type.</param>
        /// <returns>A <see cref="FeeDTO"/> representing the seller's special fee with the calculated amount.</returns>
        private FeeDTO CalculateSellersFee(PriceRequestDTO priceRequestDTO)
        {
            float sellersSpecialFee = priceRequestDTO.VehicleType == VehicleTypes.Common ?
                priceRequestDTO.BasePrice * 0.02f : priceRequestDTO.BasePrice * 0.04f;

            return new FeeDTO { Name = "Seller's Special Fee", Amount = sellersSpecialFee };
        }

        /// <summary>
        /// Calculates the association fee based on price ranges.
        /// Prices under $500 have a fee of $5, prices between $500 and $1000 have a fee of $10, and so on.
        /// </summary>
        /// <param name="priceRequestDTO">The request DTO containing the base price.</param>
        /// <returns>A <see cref="FeeDTO"/> representing the association fee with the calculated amount.</returns>
        private FeeDTO CalculateAssociationFee(PriceRequestDTO priceRequestDTO)
        {
            float associationFee = 0.0f;
            if (priceRequestDTO.BasePrice <= 500)
            {
                associationFee = 5.0f;
            }
            else if (priceRequestDTO.BasePrice <= 1000)
            {
                associationFee = 10.0f;
            }
            else if (priceRequestDTO.BasePrice <= 3000)
            {
                associationFee = 15.0f;
            }
            else
            {
                associationFee = 20.0f;
            }
            return new FeeDTO { Name = "Association Fee", Amount = associationFee };
        }

        /// <summary>
        /// Returns a fixed storage fee of $100.
        /// </summary>
        /// <param name="priceRequestDTO">The request DTO (not used in this calculation as storage fee is fixed).</param>
        /// <returns>A <see cref="FeeDTO"/> representing the storage fee with a fixed amount of $100.</returns>
        private FeeDTO CalculateStorageFee(PriceRequestDTO priceRequestDTO)
        {
            float storageFee = 100.0f;
            return new FeeDTO { Name = "Storage Fee", Amount = storageFee };
        }
    }
}
