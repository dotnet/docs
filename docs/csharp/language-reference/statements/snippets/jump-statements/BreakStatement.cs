namespace JumpStatements;

public static class BreakStatement
{
    public static void Examples()
    {
        BasicExample();
        NestedLoop();
        SwitchInsideLoop();
    }

    private static void BasicExample()
    {
        // <BasicExample>
        int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        foreach (int number in numbers)
        {
            if (number == 3)
            {
                break;
            }

            Console.Write($"{number} ");
        }
        Console.WriteLine();
        Console.WriteLine("End of the example.");
        // Output:
        // 0 1 2 
        // End of the example.
        // </BasicExample>
    }

    private static void NestedLoop()
    {
        // <NestedLoop>
        for (int outer = 0; outer < 5; outer++)
        {
            for (int inner = 0; inner < 5; inner++)
            {
                if (inner > outer)
                {
                    break;
                }

                Console.Write($"{inner} ");
            }
            Console.WriteLine();
        }
        // Output:
        // 0
        // 0 1
        // 0 1 2
        // 0 1 2 3
        // 0 1 2 3 4
        // </NestedLoop>
    }

    private static void SwitchInsideLoop()
    {
        // <SwitchInsideLoop>
        double[] measurements = { -4, 5, 30, double.NaN };
        foreach (double measurement in measurements)
        {
            switch (measurement)
            {
                case < 0.0:
                    Console.WriteLine($"Measured value is {measurement}; too low.");
                    break;

                case > 15.0:
                    Console.WriteLine($"Measured value is {measurement}; too high.");
                    break;

                case double.NaN:
                    Console.WriteLine("Failed measurement.");
                    break;

                default:
                    Console.WriteLine($"Measured value is {measurement}.");
                    break;
            }
        }
        // Output:
        // Measured value is -4; too low.
        // Measured value is 5.
        // Measured value is 30; too high.
        // Failed measurement.
        // </SwitchInsideLoop>
    }
}
