import { useState } from 'react';
import calculationService from '../services/calculationService';

const useCalculation = () => {
  const [probA, setProbA] = useState<string>('');
  const [probB, setProbB] = useState<string>('');
  const [operation, setOperation] = useState<string>('CombinedWith');
  const [result, setResult] = useState<string>('');

  const handleCalculation = async () => {
    try {
      const payload = {
        probabilityA: parseFloat(probA),
        probabilityB: parseFloat(probB),
        operationType: operation,
      };
      const response = await calculationService.calculate(payload);
      setResult(response.result);
    } catch (error) {
      console.error('Error calculating:', error);
    }
  };

  return {
    probA,
    probB,
    operation,
    result,
    setProbA,
    setProbB,
    setOperation,
    handleCalculation,
  };
};

export default useCalculation;
