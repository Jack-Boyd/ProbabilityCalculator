import React from 'react';
import Calculator from '../components/Calculator/Calculator';
import styles from './App.module.css';

const App: React.FC = () => {
  return (
    <div className='app'>
      <h1>Probability Calculator</h1>
      <div className={styles['calculator-container']}>
        <Calculator />
      </div>    
    </div>
  );
};

export default App;
