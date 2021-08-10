using System;

namespace SelectionStatements
{
    public static class SwitchStatement
    {
        public static void Examples()
        {
            Example();
            MultipleCases();
            WithCaseGuard();
        }

        private static void Example()
        {
            // <Example>
            DisplayMeasurement(-4);  // Output: Measured value is -4; too low.
            DisplayMeasurement(5);  // Output: Measured value is 5.
            DisplayMeasurement(30);  // Output: Measured value is 30; too high.
            DisplayMeasurement(double.NaN);  // Output: Failed measurement.

            void DisplayMeasurement(double measurement)
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
            // </Example>
        }

        private static void MultipleCases()
        {
            // <MultipleCases>
            DisplayMeasurement(-4);  // Output: Measured value is -4; out of an acceptable range.
            DisplayMeasurement(50);  // Output: Measured value is 50.
            DisplayMeasurement(132);  // Output: Measured value is 132; out of an acceptable range.

            void DisplayMeasurement(int measurement)
            {
                switch (measurement)
                {
                    case < 0:
                    case > 100:
                        Console.WriteLine($"Measured value is {measurement}; out of an acceptable range.");
                        break;
                    
                    default:
                        Console.WriteLine($"Measured value is {measurement}.");
                        break;
                }
            }
            // </MultipleCases>
        }

        private static void WithCaseGuard()
        {
            // <WithCaseGuard>
            DisplayMeasurements(3, 4);  // Output: First measurement is 3, second measurement is 4.
            DisplayMeasurements(5, 5);  // Output: Both measurements are valid and equal to 5.

            void DisplayMeasurements(int a, int b)
            {
                switch ((a, b))
                {
                    case (> 0, > 0) when a == b:
                        Console.WriteLine($"Both measurements are valid and equal to {a}.");
                        break;

                    case (> 0, > 0):
                        Console.WriteLine($"First measurement is {a}, second measurement is {b}.");
                        break;

                    default:
                        Console.WriteLine("One or both measurements are not valid.");
                        break;
                }
            }
            // </WithCaseGuard>
        }
    }
}