import React from 'react';
import CalculatorForm from './CalculatorForm';
import CalculatorResult from './CalculatorResult';
import useCalculation from '../../hooks/useCalculation';
import './Calculator.module.css';

const Calculator: React.FC = () => {
  const { probA, probB, operation, result, setProbA, setProbB, setOperation, handleCalculation } = useCalculation();

  return (
    <div className="calculator">
      <CalculatorForm
        probA={probA}
        probB={probB}
        operation={operation}
        setProbA={setProbA}
        setProbB={setProbB}
        setOperation={setOperation}
        onCalculate={handleCalculation}
      />
      <CalculatorResult result={result} />
    </div>
  );
};

export default Calculator;
