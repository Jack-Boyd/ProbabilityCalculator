import React, { useState } from 'react';
import styles from './Calculator.module.css';

interface CalculatorFormProps {
  probA: string;
  probB: string;
  operation: string;
  setProbA: (value: string) => void;
  setProbB: (value: string) => void;
  setOperation: (value: string) => void;
  onCalculate: () => void;
}

const CalculatorForm: React.FC<CalculatorFormProps> = ({
  probA,
  probB,
  operation,
  setProbA,
  setProbB,
  setOperation,
  onCalculate,
}) => {
  const [errors, setErrors] = useState<{ probA?: string; probB?: string }>({});

  const validateInput = (value: string): string | undefined => {
    const num = parseFloat(value);
    if (isNaN(num)) return 'Value must be a number';
    if (num < 0 || num > 1) return 'Value must be between 0 and 1';
    return undefined;
  };

  const handleProbAChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const value = e.target.value;
    const error = validateInput(value);
    setErrors((prev) => ({ ...prev, probA: error }));
    if (!error) setProbA(value);
  };

  const handleProbBChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const value = e.target.value;
    const error = validateInput(value);
    setErrors((prev) => ({ ...prev, probB: error }));
    if (!error) setProbB(value);
  };

  const handleSubmit = () => {
    const errorA = validateInput(probA);
    const errorB = validateInput(probB);

    if (errorA || errorB) {
      setErrors({ probA: errorA, probB: errorB });
    } else {
      onCalculate();
    }
  };

  return (
    <div data-testid="calculator-form" className={styles['form-container']}>
      <div className={styles['input-group']}>
        <label>P(A):</label>
        <input
          type="number"
          placeholder="Enter P(A)"
          value={probA}
          onChange={handleProbAChange}
          min="0"
          max="1"
          step="0.01"
        />
        {errors.probA && <p className={styles['error-message']}>{errors.probA}</p>}
      </div>
      <div className={styles['input-group']}>
        <label>P(B):</label>
        <input
          type="number"
          placeholder="Enter P(B)"
          value={probB}
          onChange={handleProbBChange}
          min="0"
          max="1"
          step="0.01"
        />
        {errors.probB && <p className={styles['error-message']}>{errors.probB}</p>}
      </div>
      <div className={styles['input-group']}>
        <label>
          Operation:
          <select value={operation} onChange={(e) => setOperation(e.target.value)}>
            <option value="CombinedWith">CombinedWith</option>
            <option value="Either">Either</option>
          </select>
        </label>
      </div>
      <button data-testid="calculate-button" onClick={handleSubmit}>Calculate</button>
    </div>
  );
};

export default CalculatorForm;
