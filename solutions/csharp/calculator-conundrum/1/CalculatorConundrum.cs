public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        switch (operation)
        {
            case "*":
                return $"{operand1} * {operand2} = {SimpleOperation.Multiplication(operand1, operand2)}";
                break;
            case "/":
                try {
                    return $"{operand1} / {operand2} = {SimpleOperation.Division(operand1, operand2)}";
                }
                catch (DivideByZeroException) {
                    return "Division by zero is not allowed.";
                }
                break;
            case "+":
                return $"{operand1} + {operand2} = {SimpleOperation.Addition(operand1, operand2)}";
                break;
            case "-":
                throw new ArgumentOutOfRangeException("operation", "The operation cannot be minus.");
                break;
            case null:
                throw new ArgumentNullException("operation", "The operation can not be null.");
                break;
            case "":
                Console.WriteLine(operation);
                throw new ArgumentException("operation", "The operation can not be empty.");
                break;
            default:
                throw new System.ArgumentOutOfRangeException("operation", "The operation is invalid.");
        }
    }
}
