// https://exercism.org/tracks/csharp/exercises/calculator-conundrum
// Practice exceptions

public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        double result;
        
        switch (operation)
        {
            case "+":
                result = SimpleOperation.Addition(operand1, operand2);
                break;
            case "*":
                result = SimpleOperation.Multiplication(operand1, operand2);
                break;
            case "/":
                try
                {
                    result = SimpleOperation.Division(operand1, operand2);
                    break;
                }
                catch (DivideByZeroException)
                {
                    return "Division by zero is not allowed.";
                }
            case "":
                throw new ArgumentException();
            case null:
                throw new ArgumentNullException();
            default:
                throw new ArgumentOutOfRangeException();
        }
        return $"{operand1} {operation} {operand2} = {result}";
    }
}
