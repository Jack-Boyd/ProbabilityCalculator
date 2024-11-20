using System.Text.Json;
using ProbabilityCalculatorAPI.Infrastructure.Services;

namespace ProbabilityCalculatorAPI.Application.Handlers {
    public class GetCalculationLogsQueryHandler {
        public object[] Handle() {
            var logLines = EventLogger.ReadAllLogs();
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
