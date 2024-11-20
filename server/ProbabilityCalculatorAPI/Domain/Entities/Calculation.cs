namespace ProbabilityCalculatorAPI.Domain.Entities {
    public class Calculation {
        public decimal ProbabilityA { get; private set; }
        public decimal ProbabilityB { get; private set; }
        public string OperationType { get; private set; }
        public decimal Result { get; private set; }

        public Calculation(decimal probabilityA, decimal probabilityB, string operationType) {
            if (probabilityA < 0 || probabilityA > 1 || probabilityB < 0 || probabilityB > 1)
                throw new ArgumentException("Probabilities must be between 0 and 1.");

            ProbabilityA = probabilityA;
            ProbabilityB = probabilityB;
            OperationType = operationType;
        }

        public void Calculate() {
            Result = OperationType switch {
                "CombinedWith" => ProbabilityA * ProbabilityB,
                "Either" => ProbabilityA + ProbabilityB - (ProbabilityA * ProbabilityB),
                _ => throw new InvalidOperationException("Invalid operation type")
            };
        }
    }
}
