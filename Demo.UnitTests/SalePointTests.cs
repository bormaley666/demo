using Demo.Application.Models;
using Demo.Common.Exceptions;
using Xunit;

namespace Demo.UnitTests;

public class SalePointTests
{
    [Fact]
    public void StockProductQuantity_Default_ChangeProductQuantity()
    {
        // Arrange
        var productId = Guid.NewGuid();
        var sut = new SalePoint("sale-point");

        // Act
        sut.StockProductQuantity(productId, 10);

        // Assert
        Assert.Equal(10, sut.GetAvailableProductQuantity(productId));
    }

    [Fact]
    public void ConsumeProductQuantity_Default_ChangeProductQuantity()
    {
        // Arrange
        var productId = Guid.NewGuid();
        var sut = new SalePoint("sale-point");

        // Act
        sut.StockProductQuantity(productId, 10);
        sut.ConsumeProductQuantity(productId, 10);

        // Assert
        Assert.Equal(0, sut.GetAvailableProductQuantity(productId));
    }

    [Fact]
    public void ConsumeProductQuantity_ProductQuantityExceeded_ThrowsException()
    {
        // Arrange
        var productId = Guid.NewGuid();
        var sut = new SalePoint("sale-point");

        // Act
        sut.StockProductQuantity(productId, 10);
        var act = () => sut.ConsumeProductQuantity(productId, 11);

        // Assert
        var exception = Assert.Throws<SalePointException>(act);
    }
}