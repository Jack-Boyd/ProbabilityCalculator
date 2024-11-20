using ProbabilityCalculatorAPI.Application.Commands;
using ProbabilityCalculatorAPI.Domain.Entities;
using ProbabilityCalculatorAPI.Infrastructure.Services;

namespace ProbabilityCalculatorAPI.Application.Handlers {
    public class CalculateCommandHandler {
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

            EventLogger.LogEvent(logEntry);
        }
    }
}
