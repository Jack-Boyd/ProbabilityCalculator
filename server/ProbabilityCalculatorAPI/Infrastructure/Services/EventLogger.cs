using System.Text.Json;
using ProbabilityCalculatorAPI.Infrastructure.Interfaces;

namespace ProbabilityCalculatorAPI.Infrastructure.Services {
    public class EventLogger : IEventLogger {
        private const string LogFilePath = "events.log";

        public void LogEvent<T>(T eventData) {
            string eventJson = JsonSerializer.Serialize(new { Timestamp = DateTime.Now, EventData = eventData });
            System.IO.File.AppendAllText(LogFilePath, eventJson + Environment.NewLine);
        }

        public string[] ReadAllLogs() {
            if (!System.IO.File.Exists(LogFilePath))
                return Array.Empty<string>();

            return System.IO.File.ReadAllLines(LogFilePath);
        }
    }
}
