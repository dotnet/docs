//<Snippet74>
public static class SquareExample
{
    public static void Main()
    {
        // Call with an int variable.
        var num = 4;
        var productA = Square(num);

        // Call with an integer literal.
        var productB = Square(12);

        // Call with an expression that evaluates to int.
        var productC = Square(productA * 3);
    }

    static int Square(int i)
    {
        // Store input argument in a local variable.
        var input = i;
        return input * input;
    }
}
//</Snippet74>
