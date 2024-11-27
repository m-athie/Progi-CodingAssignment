using CarPriceAPI.DTOs;
using CarPriceAPI.Models.Types;
using CarPriceAPI.Services;

namespace CarPriceAPI.Tests;

[TestClass]
public class PricesServiceTests
{
    private PricesService _pricesService;

    [TestInitialize]
    public void Initialize()
    {
        _pricesService = new PricesService();
    }

    [TestMethod]
    public void CalculatePrice_ShouldCalculateCorrectTotalPrice_ForCase1()
    {
        // Arrange
        var priceRequestDTO = new PriceRequestDTO
        {
            BasePrice = 398,
            VehicleType = VehicleTypes.Common
        };

        // Act
        var result = _pricesService.CalculatePrice(priceRequestDTO);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(550.76, result.TotalPrice, 0.01);  
        Assert.AreEqual(4, result.AppliedFees.Count);  
        Assert.IsTrue(result.AppliedFees.Exists(fee => fee.Name == "Basic Buyer Fee" && fee.Amount-39.8<0.01));
        Assert.IsTrue(result.AppliedFees.Exists(fee => fee.Name == "Seller's Special Fee" && fee.Amount - 7.96 < 0.01));
        Assert.IsTrue(result.AppliedFees.Exists(fee => fee.Name == "Association Fee" && fee.Amount - 5 < 0.01));
        Assert.IsTrue(result.AppliedFees.Exists(fee => fee.Name == "Storage Fee" && fee.Amount - 100 < 0.01));
    }

    [TestMethod]
    public void CalculatePrice_ShouldCalculateCorrectTotalPrice_ForCase2()
    {
        // Arrange
        var priceRequestDTO = new PriceRequestDTO
        {
            BasePrice = 501,
            VehicleType = VehicleTypes.Common
        };

        // Act
        var result = _pricesService.CalculatePrice(priceRequestDTO);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(671.02, result.TotalPrice, 0.01);  
        Assert.AreEqual(4, result.AppliedFees.Count);  
        Assert.IsTrue(result.AppliedFees.Exists(fee => fee.Name == "Basic Buyer Fee" && fee.Amount - 50 < 0.01));
        Assert.IsTrue(result.AppliedFees.Exists(fee => fee.Name == "Seller's Special Fee" && fee.Amount - 10.02 < 0.01));
        Assert.IsTrue(result.AppliedFees.Exists(fee => fee.Name == "Association Fee" && fee.Amount - 10 < 0.01));
        Assert.IsTrue(result.AppliedFees.Exists(fee => fee.Name == "Storage Fee" && fee.Amount - 100 < 0.01));
    }

    [TestMethod]
    public void CalculatePrice_ShouldCalculateCorrectTotalPrice_ForCase3()
    {
        // Arrange
        var priceRequestDTO = new PriceRequestDTO
        {
            BasePrice = 57,
            VehicleType = VehicleTypes.Common
        };

        // Act
        var result = _pricesService.CalculatePrice(priceRequestDTO);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(173.14, result.TotalPrice, 0.01);  
        Assert.AreEqual(4, result.AppliedFees.Count, 0.01);  
        Assert.IsTrue(result.AppliedFees.Exists(fee => fee.Name == "Basic Buyer Fee" && fee.Amount - 10 < 0.01));
        Assert.IsTrue(result.AppliedFees.Exists(fee => fee.Name == "Seller's Special Fee" && fee.Amount - 1.14 < 0.01));
        Assert.IsTrue(result.AppliedFees.Exists(fee => fee.Name == "Association Fee" && fee.Amount - 5 < 0.01));
        Assert.IsTrue(result.AppliedFees.Exists(fee => fee.Name == "Storage Fee" && fee.Amount - 100 < 0.01));
    }

    [TestMethod]
    public void CalculatePrice_ShouldCalculateCorrectTotalPrice_ForCase4()
    {
        // Arrange
        var priceRequestDTO = new PriceRequestDTO
        {
            BasePrice = 1800,
            VehicleType = VehicleTypes.Luxury
        };

        // Act
        var result = _pricesService.CalculatePrice(priceRequestDTO);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(2167, result.TotalPrice, 0.01);  
        Assert.AreEqual(4, result.AppliedFees.Count);  
        Assert.IsTrue(result.AppliedFees.Exists(fee => fee.Name == "Basic Buyer Fee" && fee.Amount - 180 < 0.01));
        Assert.IsTrue(result.AppliedFees.Exists(fee => fee.Name == "Seller's Special Fee" && fee.Amount - 72 < 0.01));
        Assert.IsTrue(result.AppliedFees.Exists(fee => fee.Name == "Association Fee" && fee.Amount - 15 < 0.01));
        Assert.IsTrue(result.AppliedFees.Exists(fee => fee.Name == "Storage Fee" && fee.Amount - 100 < 0.01));
    }

    [TestMethod]
    public void CalculatePrice_ShouldCalculateCorrectTotalPrice_ForCase5()
    {
        // Arrange
        var priceRequestDTO = new PriceRequestDTO
        {
            BasePrice = 1100,
            VehicleType = VehicleTypes.Common
        };

        // Act
        var result = _pricesService.CalculatePrice(priceRequestDTO);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(1287, result.TotalPrice, 0.01); 
        Assert.AreEqual(4, result.AppliedFees.Count);  
        Assert.IsTrue(result.AppliedFees.Exists(fee => fee.Name == "Basic Buyer Fee" && fee.Amount - 50 < 0.01));
        Assert.IsTrue(result.AppliedFees.Exists(fee => fee.Name == "Seller's Special Fee" && fee.Amount - 22 < 0.01));
        Assert.IsTrue(result.AppliedFees.Exists(fee => fee.Name == "Association Fee" && fee.Amount - 15 < 0.01));
        Assert.IsTrue(result.AppliedFees.Exists(fee => fee.Name == "Storage Fee" && fee.Amount - 100 < 0.01));
    }


    [TestMethod]
    public void CalculatePrice_ShouldCalculateCorrectTotalPrice_ForCase6()
    {
        // Arrange
        var priceRequestDTO = new PriceRequestDTO
        {
            BasePrice = 1000000,
            VehicleType = VehicleTypes.Luxury
        };

        // Act
        var result = _pricesService.CalculatePrice(priceRequestDTO);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(1040320, result.TotalPrice, 0.01);  
        Assert.AreEqual(4, result.AppliedFees.Count);  
        Assert.IsTrue(result.AppliedFees.Exists(fee => fee.Name == "Basic Buyer Fee" && fee.Amount - 200 < 0.01));
        Assert.IsTrue(result.AppliedFees.Exists(fee => fee.Name == "Seller's Special Fee" && fee.Amount - 40000 < 0.01));
        Assert.IsTrue(result.AppliedFees.Exists(fee => fee.Name == "Association Fee" && fee.Amount - 20 < 0.01));
        Assert.IsTrue(result.AppliedFees.Exists(fee => fee.Name == "Storage Fee" && fee.Amount - 100 < 0.01));
    }

    [TestMethod]
    public void CalculatePrice_ShouldCalculateCorrectTotalPrice_ForLuxuryVehicle()
    {
        // Arrange
        var priceRequestDTO = new PriceRequestDTO
        {
            BasePrice = 3000,
            VehicleType = VehicleTypes.Luxury
        };

        // Act
        var result = _pricesService.CalculatePrice(priceRequestDTO);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(3000 + 200 + 120 + 15 + 100, result.TotalPrice, 0.01);
        Assert.AreEqual(4, result.AppliedFees.Count);
        Assert.IsTrue(result.AppliedFees.Exists(fee => fee.Name == "Basic Buyer Fee" && fee.Amount - 200 < 0.01));
        Assert.IsTrue(result.AppliedFees.Exists(fee => fee.Name == "Seller's Special Fee" && fee.Amount - 120 < 0.01));
        Assert.IsTrue(result.AppliedFees.Exists(fee => fee.Name == "Association Fee" && fee.Amount - 15 < 0.01));
        Assert.IsTrue(result.AppliedFees.Exists(fee => fee.Name == "Storage Fee" && fee.Amount - 100 < 0.01));
    }
}
