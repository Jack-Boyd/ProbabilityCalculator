using System.Text.Json;
using ProbabilityCalculatorAPI.Infrastructure.Interfaces;

namespace ProbabilityCalculatorAPI.Application.Handlers {
    public class GetCalculationLogsQueryHandler {
        private readonly IEventLogger _logger;

        public GetCalculationLogsQueryHandler(IEventLogger logger) {
            _logger = logger;
        }

        public object[] Handle() {
            var logLines = _logger.ReadAllLogs();
            return logLines
                .Select(logLine => {
                    try {
                        return JsonSerializer.Deserialize<object>(logLine);
                    }
                    catch {
                        return null;
                    }
                })
                .Where(entry => entry != null)
                .ToArray()!;
        }
    }
}
