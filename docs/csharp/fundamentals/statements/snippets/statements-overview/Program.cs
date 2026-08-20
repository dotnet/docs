namespace StatementsOverview;

public static class Program
{
    public static void Main()
    {
        ShowStatementRecipe();
        ShowBlocksAndScope();
    }

    private static void ShowStatementRecipe()
    {
        // <StatementRecipe>
        int quantity = 5;
        Console.WriteLine($"Quantity: {quantity}"); // => Quantity: 5

        if (quantity < 10)
        {
            quantity = 10;
            Console.WriteLine("Restocked"); // => Restocked
        }

        Console.WriteLine($"Quantity: {quantity}"); // => Quantity: 10
        // </StatementRecipe>
    }

    private static void ShowBlocksAndScope()
    {
        // <BlocksAndScope>
        int outerValue = 10;

        if (outerValue > 0)
        {
            int innerValue = outerValue * 2;
            Console.WriteLine(innerValue); // => 20
        }

        // innerValue isn't in scope here.
        // </BlocksAndScope>
    }
}
