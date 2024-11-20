using ProbabilityCalculatorAPI.Application.Commands;
using ProbabilityCalculatorAPI.Domain.Entities;
using ProbabilityCalculatorAPI.Infrastructure.Interfaces;

namespace ProbabilityCalculatorAPI.Application.Handlers {
    public class CalculateCommandHandler {
        private readonly IEventLogger _logger;
        public CalculateCommandHandler(IEventLogger logger) {
            _logger = logger;
        }
        public Calculation Handle(CalculateCommand command) {
            Console.WriteLine(command);
            var calculation = new Calculation(command.ProbabilityA, command.ProbabilityB, command.OperationType);
            calculation.Calculate();
            LogCalculation(calculation);
            return calculation;
        }

        private void LogCalculation(Calculation calculation) {
            var logEntry = new {
                Timestamp = DateTime.Now,
                Operation = calculation.OperationType,
                ProbabilityA = calculation.ProbabilityA,
                ProbabilityB = calculation.ProbabilityB,
                Result = calculation.Result
            };

            _logger.LogEvent(logEntry);
        }
    }
}
