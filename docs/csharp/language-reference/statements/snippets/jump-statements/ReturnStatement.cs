namespace JumpStatements;

public static class ReturnStatement
{
    public static void Examples()
    {
        WithoutExpression();
        WithExpression();
        RefReturn();
    }

    private static void WithoutExpression()
    {
        // <WithoutExpression>
        Console.WriteLine("First call:");
        DisplayIfNecessary(6);

        Console.WriteLine("Second call:");
        DisplayIfNecessary(5);

        void DisplayIfNecessary(int number)
        {
            if (number % 2 == 0)
            {
                return;
            }

            Console.WriteLine(number);
        }
        // Output:
        // First call:
        // Second call:
        // 5
        // </WithoutExpression>
    }

    private static void WithExpression()
    {
        // <WithExpression>
        double surfaceArea = CalculateCylinderSurfaceArea(1, 1);
        Console.WriteLine($"{surfaceArea:F2}"); // output: 12.57

        double CalculateCylinderSurfaceArea(double baseRadius, double height)
        {
            double baseArea = Math.PI * baseRadius * baseRadius;
            double sideArea = 2 * Math.PI * baseRadius * height;
            return 2 * baseArea + sideArea;
        }
        // </WithExpression>
    }

    private static void RefReturn()
    {
        // <RefReturn>
        var xs = new int[] { 10, 20, 30, 40 };
        ref int found = ref FindFirst(xs, s => s == 30);
        found = 0;
        Console.WriteLine(string.Join(" ", xs));  // output: 10 20 0 40
        
        ref int FindFirst(int[] numbers, Func<int, bool> predicate)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (predicate(numbers[i]))
                {
                    return ref numbers[i];
                }
            }
            throw new InvalidOperationException("No element satisfies the given condition.");
        }
        // </RefReturn>
    }
}
