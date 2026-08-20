using System.Text;

namespace StatementsOverview;

public static class Program
{
    public static async Task Main()
    {
        await ShowExpressionStatements();
        ShowBlocksAndScope();
    }

    private static async Task ShowExpressionStatements()
    {
        // <ExpressionStatements>
        int quantity = 0;

        quantity = 5;                       // Assignment
        Console.WriteLine(quantity);        // Method invocation // => 5
        new StringBuilder();                // Object creation
        quantity++;                         // Postfix increment
        --quantity;                         // Prefix decrement
        await Task.CompletedTask;           // Await expression
        // </ExpressionStatements>
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
