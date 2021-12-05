namespace JumpStatements;

public static class GotoStatement
{
    public static void Examples()
    {
        NestedLoops();
        GotoInSwitchExample.Main();
    }

    private static void NestedLoops()
    {
        // <NestedLoops>
        var matrices = new Dictionary<string, int[][]>
        {
            ["A"] = new[]
            {
                new[] { 1, 2, 3, 4 },
                new[] { 4, 3, 2, 1 }
            },
            ["B"] = new[]
            {
                new[] { 5, 6, 7, 8 },
                new[] { 8, 7, 6, 5 }
            },
        };

        CheckMatrices(matrices, 4);

        void CheckMatrices(Dictionary<string, int[][]> matrixLookup, int target)
        {
            foreach (var (key, matrix) in matrixLookup)
            {
                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (matrix[row][col] == target)
                        {
                            goto Found;
                        }
                    }
                }
                Console.WriteLine($"Not found {target} in matrix {key}.");
                continue;

            Found:
                Console.WriteLine($"Found {target} in matrix {key}.");
            }
        }
        // Output:
        // Found 4 in matrix A.
        // Not found 4 in matrix B.
        // </NestedLoops>
    }

    // <InsideSwitch>
    public enum CoffeChoice
    {
        Plain,
        WithMilk,
        WithIceCream,
    }

    public class GotoInSwitchExample
    {
        public static void Main()
        {
            Console.WriteLine(CalculatePrice(CoffeChoice.Plain));  // output: 10.0
            Console.WriteLine(CalculatePrice(CoffeChoice.WithMilk));  // output: 15.0
            Console.WriteLine(CalculatePrice(CoffeChoice.WithIceCream));  // output: 17.0
        }

        private static decimal CalculatePrice(CoffeChoice choice)
        {
            decimal price = 0;
            switch (choice)
            {
                case CoffeChoice.Plain:
                    price += 10.0m;
                    break;

                case CoffeChoice.WithMilk:
                    price += 5.0m;
                    goto case CoffeChoice.Plain;

                case CoffeChoice.WithIceCream:
                    price += 7.0m;
                    goto case CoffeChoice.Plain;
            }
            return price;
        }
        // </InsideSwitch>
    }
}
