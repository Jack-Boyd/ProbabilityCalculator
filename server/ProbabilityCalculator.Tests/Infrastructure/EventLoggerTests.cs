using Xunit;
using Moq;
using System.IO;
using ProbabilityCalculatorAPI.Infrastructure.Services;

public class EventLoggerTests
{
    [Fact]
    public void LogEvent_ValidEvent_WritesToLogFile()
    {
        // Arrange
        var logger = new EventLogger();
        var eventData = new { ProbabilityA = 0.5, ProbabilityB = 0.5, Result = 0.25 };

        if (File.Exists("events.log"))
            File.Delete("events.log");

        // Act
        logger.LogEvent(eventData);

        // Assert
        var logs = File.ReadAllLines("events.log");
        Assert.NotEmpty(logs);
        Assert.Contains("ProbabilityA", logs[0]);
    }
}
