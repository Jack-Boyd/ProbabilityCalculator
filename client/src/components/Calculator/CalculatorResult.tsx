import React from 'react';
import styles from './Calculator.module.css';

interface CalculatorResultProps {
  result: string;
}

const CalculatorResult: React.FC<CalculatorResultProps> = ({ result }) => (
  <div data-testid="calculator-result" className={styles['calculator-result']}>
    {result && <>
      <h3>Result</h3>
      <p>{result}</p>
    </>}
  </div>
);

export default CalculatorResult;
