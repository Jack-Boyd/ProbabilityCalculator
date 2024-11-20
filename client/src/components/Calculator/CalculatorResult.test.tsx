import { render, screen } from '@testing-library/react';
import CalculatorResult from './CalculatorResult';

describe('CalculatorResult', () => {
  it('displays the calculation result', () => {
    render(<CalculatorResult result="Result: 0.25" />);
    const resultText = screen.getByText(/Result: 0.25/i);
    expect(resultText).toBeInTheDocument();
  });

  it('does not render result text if result is empty', () => {
    render(<CalculatorResult result="" />);
    const resultText = screen.queryByText(/Result:/i);
    expect(resultText).not.toBeInTheDocument();
  });
});
