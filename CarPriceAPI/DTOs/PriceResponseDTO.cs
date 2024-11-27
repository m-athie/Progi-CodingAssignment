namespace CarPriceAPI.DTOs
{
    public class PriceResponseDTO
    {
        public float TotalPrice { get; set; } 
        public List<FeeDTO> AppliedFees { get; set; } 
    }
}
