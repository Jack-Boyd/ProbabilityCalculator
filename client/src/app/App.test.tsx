import { render, screen } from '@testing-library/react';
import App from './App';

describe('App', () => {
  it('renders the app title', () => {
    render(<App />);
    const titleElement = screen.getByText(/Probability Calculator/i);
    expect(titleElement).toBeInTheDocument();
  });

  it('renders the Calculator component', () => {
    render(<App />);
    const calculatorElement = screen.getByTestId('calculator-form');
    expect(calculatorElement).toBeInTheDocument();
  });
});
