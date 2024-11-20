using Xunit;
using Moq;
using ProbabilityCalculatorAPI.Application.Commands;
using ProbabilityCalculatorAPI.Application.Handlers;
using ProbabilityCalculatorAPI.Infrastructure.Interfaces;
using ProbabilityCalculatorAPI.Infrastructure.Services;

public class CalculateCommandHandlerTests
{
  [Fact]
  public void Handle_ValidInput_ReturnsExpectedResult()
  {
    var command = new CalculateCommand
    {
      ProbabilityA = 0.7m,
      ProbabilityB = 0.8m,
      OperationType = "CombinedWith"
    };
    var mockLogger = new Mock<IEventLogger>();
    var handler = new CalculateCommandHandler(mockLogger.Object);

    var result = handler.Handle(command);

    Assert.Equal(0.56m, result.Result);
    mockLogger.Verify(logger => logger.LogEvent(It.IsAny<object>()), Times.Once);
  }

  [Fact]
  public void Handle_InvalidProbability_ThrowsArgumentException()
  {
      // Arrange
      var command = new CalculateCommand
      {
        ProbabilityA = -0.5m,
        ProbabilityB = 0.5m,
        OperationType = "CombinedWith"
      };
      var mockLogger = new Mock<EventLogger>();
      var handler = new CalculateCommandHandler(mockLogger.Object);

      // Act & Assert
      Assert.Throws<ArgumentException>(() => handler.Handle(command));
  }
}
