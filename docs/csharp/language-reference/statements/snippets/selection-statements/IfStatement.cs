using System;

namespace SelectionStatements
{
    public static class IfStatement
    {
        public static void Examples()
        {
            IfElse();
            OnlyIf();
            NestedIf();
        }

        private static void IfElse()
        {
            // <IfElse>
            DisplayWeatherReport(15.0);  // Output: Cold.
            DisplayWeatherReport(24.0);  // Output: Perfect!

            void DisplayWeatherReport(double tempInCelsius)
            {
                if (tempInCelsius < 20.0)
                {
                    Console.WriteLine("Cold.");
                }
                else
                {
                    Console.WriteLine("Perfect!");
                }
            }
            // </IfElse>
        }

        private static void OnlyIf()
        {
            // <OnlyIf>
            DisplayMeasurement(45);  // Output: The measurement value is 45
            DisplayMeasurement(-3);  // Output: Warning: not acceptable value! The measurement value is -3

            void DisplayMeasurement(double value)
            {
                if (value < 0 || value > 100)
                {
                    Console.Write("Warning: not acceptable value! ");
                }

                Console.WriteLine($"The measurement value is {value}");
            }
            // </OnlyIf>
        }

        private static void NestedIf()
        {
            // <NestedIf>
            DisplayCharacter('f');  // Output: A lowercase letter: f
            DisplayCharacter('R');  // Output: An uppercase letter: R
            DisplayCharacter('8');  // Output: A digit: 8
            DisplayCharacter(',');  // Output: Not alphanumeric character: ,

            void DisplayCharacter(char ch)
            {
                if (char.IsUpper(ch))
                {
                    Console.WriteLine($"An uppercase letter: {ch}");
                }
                else if (char.IsLower(ch))
                {
                    Console.WriteLine($"A lowercase letter: {ch}");
                }
                else if (char.IsDigit(ch))
                {
                    Console.WriteLine($"A digit: {ch}");
                }
                else
                {
                    Console.WriteLine($"Not alphanumeric character: {ch}");
                }
            }
            // </NestedIf>
        }
    }
}