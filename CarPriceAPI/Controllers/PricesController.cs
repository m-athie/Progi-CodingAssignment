using CarPriceAPI.DTOs;
using CarPriceAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarPriceAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class PricesController : ControllerBase
{
    IPricesService _priceService;
    public PricesController(IPricesService pricesService)
    {
        _priceService = pricesService;
    }

    [HttpPost]
    public ActionResult<PriceResponseDTO> CalculatePrice([FromBody] PriceRequestDTO priceRequestDTO)
    {
        var priceResponse = _priceService.CalculatePrice(priceRequestDTO);

        return Ok(priceResponse);
    }
}

