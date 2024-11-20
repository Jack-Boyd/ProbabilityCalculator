import { render, screen, fireEvent } from '@testing-library/react';
import CalculatorForm from './CalculatorForm';

describe('CalculatorForm', () => {
  const mockSetProbA = jest.fn();
  const mockSetProbB = jest.fn();
  const mockSetOperation = jest.fn();
  const mockOnCalculate = jest.fn();

  beforeEach(() => {
    jest.clearAllMocks();
  });

  it('renders all form elements', () => {
    render(
      <CalculatorForm
        probA=""
        probB=""
        operation="CombinedWith"
        setProbA={mockSetProbA}
        setProbB={mockSetProbB}
        setOperation={mockSetOperation}
        onCalculate={mockOnCalculate}
      />
    );

    const inputA = screen.getByPlaceholderText('Enter P(A)');
    const inputB = screen.getByPlaceholderText('Enter P(B)');
    const operationDropdown = screen.getByRole('combobox');
    const calculateButton = screen.getByTestId('calculate-button');

    expect(inputA).toBeInTheDocument();
    expect(inputB).toBeInTheDocument();
    expect(operationDropdown).toBeInTheDocument();
    expect(calculateButton).toBeInTheDocument();
  });

  it('restricts input values to between 0 and 1 for P(A)', () => {
    render(
      <CalculatorForm
        probA=""
        probB=""
        operation="CombinedWith"
        setProbA={mockSetProbA}
        setProbB={mockSetProbB}
        setOperation={mockSetOperation}
        onCalculate={mockOnCalculate}
      />
    );

    const inputA = screen.getByPlaceholderText('Enter P(A)');
    fireEvent.change(inputA, { target: { value: '1.5' } });

    expect(mockSetProbA).not.toHaveBeenCalledWith('1.5'); // Invalid input should not update state

    fireEvent.change(inputA, { target: { value: '0.8' } });
    expect(mockSetProbA).toHaveBeenCalledWith('0.8'); // Valid input should update state
  });

  it('calls setOperation when the dropdown value changes', () => {
    render(
      <CalculatorForm
        probA=""
        probB=""
        operation="CombinedWith"
        setProbA={mockSetProbA}
        setProbB={mockSetProbB}
        setOperation={mockSetOperation}
        onCalculate={mockOnCalculate}
      />
    );

    const operationDropdown = screen.getByRole('combobox');
    fireEvent.change(operationDropdown, { target: { value: 'Either' } });

    expect(mockSetOperation).toHaveBeenCalledWith('Either');
  });

  it('calls onCalculate when Calculate button is clicked', () => {
    render(
      <CalculatorForm
        probA="0.5"
        probB="0.6"
        operation="CombinedWith"
        setProbA={mockSetProbA}
        setProbB={mockSetProbB}
        setOperation={mockSetOperation}
        onCalculate={mockOnCalculate}
      />
    );

    const calculateButton = screen.getByTestId('calculate-button');
    fireEvent.click(calculateButton);

    expect(mockOnCalculate).toHaveBeenCalled();
  });

  it('displays validation errors for invalid inputs', () => {
    render(
      <CalculatorForm
        probA=""
        probB=""
        operation="CombinedWith"
        setProbA={mockSetProbA}
        setProbB={mockSetProbB}
        setOperation={mockSetOperation}
        onCalculate={mockOnCalculate}
      />
    );

    const inputA = screen.getByPlaceholderText('Enter P(A)');
    fireEvent.change(inputA, { target: { value: '-0.1' } });

    const errorMessage = screen.getByText(/Value must be between 0 and 1/i);
    expect(errorMessage).toBeInTheDocument();
  });
  it('calls setProbB with valid input and updates errors with invalid input', () => {
    render(
      <CalculatorForm
        probA=""
        probB=""
        operation="CombinedWith"
        setProbA={mockSetProbA}
        setProbB={mockSetProbB}
        setOperation={mockSetOperation}
        onCalculate={mockOnCalculate}
      />
    );

    const inputB = screen.getByPlaceholderText('Enter P(B)');

    // Valid input
    fireEvent.change(inputB, { target: { value: '0.5' } });
    expect(mockSetProbB).toHaveBeenCalledWith('0.5');

    // Invalid input
    fireEvent.change(inputB, { target: { value: '1.5' } });
    const errorMessage = screen.getByText(/Value must be between 0 and 1/i);
    expect(errorMessage).toBeInTheDocument();
    expect(mockSetProbB).not.toHaveBeenCalledWith('1.5');
  });

  it('validates inputs and calls onCalculate in handleSubmit', () => {
    render(
      <CalculatorForm
        probA="0.6"
        probB="0.8"
        operation="CombinedWith"
        setProbA={mockSetProbA}
        setProbB={mockSetProbB}
        setOperation={mockSetOperation}
        onCalculate={mockOnCalculate}
      />
    );

    const calculateButton = screen.getByTestId('calculate-button');

    fireEvent.click(calculateButton);
    expect(mockOnCalculate).toHaveBeenCalled();
  });
  it('validates inputs and does not call onCalculate in handleSubmit', () => {
    render(
      <CalculatorForm
        probA=""
        probB="1.2" // Invalid value
        operation="CombinedWith"
        setProbA={mockSetProbA}
        setProbB={mockSetProbB}
        setOperation={mockSetOperation}
        onCalculate={mockOnCalculate}
      />
    );

    const invalidButton = screen.getByTestId('calculate-button');
    fireEvent.click(invalidButton);

    expect(mockOnCalculate).not.toHaveBeenCalled();
    const errorMessages = screen.getAllByText(/Value must be between 0 and 1/i);
    expect(errorMessages.length).toBeGreaterThan(0);
  });
});
