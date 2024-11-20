using System.Text.Json;

namespace ProbabilityCalculatorAPI.Infrastructure.Services
{
    public static class EventLogger
    {
        private const string LogFilePath = "events.log";

        public static void LogEvent<T>(T eventData)
        {
            string eventJson = JsonSerializer.Serialize(new { Timestamp = DateTime.Now, EventData = eventData });
            System.IO.File.AppendAllText(LogFilePath, eventJson + Environment.NewLine);
        }

        public static string[] ReadAllLogs()
        {
            if (!System.IO.File.Exists(LogFilePath))
                return Array.Empty<string>();

            return System.IO.File.ReadAllLines(LogFilePath);
        }
    }
}
