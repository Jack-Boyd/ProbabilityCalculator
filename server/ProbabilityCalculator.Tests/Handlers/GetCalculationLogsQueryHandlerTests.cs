using Xunit;
using Moq;
using ProbabilityCalculatorAPI.Application.Handlers;
using ProbabilityCalculatorAPI.Infrastructure.Interfaces;

public class GetCalculationLogsQueryHandlerTests {
    [Fact]
    public void Handle_LogsExist_ReturnsParsedLogs() {
        var mockLogger = new Mock<IEventLogger>();
        var logs = new[] { "{\"Timestamp\":\"2024-11-20\",\"Result\":0.45}" };

        mockLogger.Setup(logger => logger.ReadAllLogs()).Returns(logs);

        var handler = new GetCalculationLogsQueryHandler(mockLogger.Object);

        var result = handler.Handle();

        Assert.NotNull(result);
        Assert.Single(result);
    }

    [Fact]
    public void Handle_NoLogs_ReturnsEmptyList() {
        var mockLogger = new Mock<IEventLogger>();

        mockLogger.Setup(logger => logger.ReadAllLogs()).Returns(new string[0]);

        var handler = new GetCalculationLogsQueryHandler(mockLogger.Object);

        var result = handler.Handle();

        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void Handle_InvalidLogEntry_IgnoresMalformedLog() {
        var mockLogger = new Mock<IEventLogger>();
        var logs = new[] { "{\"Timestamp\":\"2024-11-20\",\"Result\":0.45}", "InvalidLogEntry" };

        mockLogger.Setup(logger => logger.ReadAllLogs()).Returns(logs);

        var handler = new GetCalculationLogsQueryHandler(mockLogger.Object);

        var result = handler.Handle();

        Assert.NotNull(result);
        Assert.Single(result);
    }
}
