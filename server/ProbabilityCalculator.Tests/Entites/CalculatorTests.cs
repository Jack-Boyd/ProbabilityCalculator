using Xunit;
using ProbabilityCalculatorAPI.Domain.Entities;

public class CalculationTests
{
    [Theory]
    [InlineData(0.9, 0.8, "CombinedWith", 0.72)]
    [InlineData(0.9, 0.8, "Either", 0.98)]
    public void Calculate_ShouldReturnExpectedResult(decimal probA, decimal probB, string operation, decimal expected)
    {
        // Arrange
        var calculation = new Calculation(probA, probB, operation);

        // Act
        calculation.Calculate();

        // Assert
        Assert.Equal(expected, calculation.Result, precision: 10);
    }

    [Fact]
    public void Calculate_InvalidProbabilities_ShouldThrowArgumentException()
    {
        // Arrange
        decimal invalidProbability = 1.5m;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Calculation(invalidProbability, 0.8m, "CombinedWith"));
    }
}
