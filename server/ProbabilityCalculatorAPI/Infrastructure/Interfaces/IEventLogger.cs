namespace ProbabilityCalculatorAPI.Infrastructure.Interfaces {
  public interface IEventLogger
  {
      void LogEvent<T>(T eventData);
      string[] ReadAllLogs();
  }
}
