namespace ProbabilityCalculatorAPI.Application.Commands
{
    public class CalculateCommand
    {
        public double ProbabilityA { get; set; }
        public double ProbabilityB { get; set; }
        public string OperationType { get; set; } = "CombinedWith";
    }
}
