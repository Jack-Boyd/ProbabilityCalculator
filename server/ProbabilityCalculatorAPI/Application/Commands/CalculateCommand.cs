namespace ProbabilityCalculatorAPI.Application.Commands {
    public class CalculateCommand {
        public decimal ProbabilityA { get; set; }
        public decimal ProbabilityB { get; set; }
        public string OperationType { get; set; } = "CombinedWith";
    }
}
