import { render, screen } from '@testing-library/react';
import Calculator from './Calculator';

describe('Calculator', () => {
  it('renders the CalculatorForm component', () => {
    render(<Calculator />);
    const formElement = screen.getByTestId('calculator-form');
    expect(formElement).toBeInTheDocument();
  });
  it('renders the CalculatorResult component', () => {
    render(<Calculator />);
    const resultElement = screen.getByTestId('calculator-result');
    expect(resultElement).toBeInTheDocument();
  });
});
