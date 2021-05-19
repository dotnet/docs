using System;

namespace Patterns
{
    public static class LogicalPatterns
    {
        public static void Examples()
        {
            AndPattern();
            OrPattern();
        }

        private static void NotPattern(object input)
        {
            // <NotPattern>
            if (input is not null)
            {
                // ...
            }
            // </NotPattern>
        }

        private static void AndPattern()
        {
            // <AndPattern>
            Console.WriteLine(Classify(13));  // output: High
            Console.WriteLine(Classify(-100));  // output: Too low
            Console.WriteLine(Classify(5.7));  // output: Acceptable

            static string Classify(double measurement) => measurement switch
            {
                < -40.0 => "Too low",
                >= -40.0 and < 0 => "Low",
                >= 0 and < 10.0 => "Acceptable",
                >= 10.0 and < 20.0 => "High",
                >= 20.0 => "Too high",
                double.NaN => "Unknown",
            };
            // </AndPattern>
        }

        private static void OrPattern()
        {
            // <OrPattern>
            Console.WriteLine(GetCalendarSeason(new DateTime(2021, 1, 19)));  // output: winter
            Console.WriteLine(GetCalendarSeason(new DateTime(2021, 10, 9)));  // output: autumn
            Console.WriteLine(GetCalendarSeason(new DateTime(2021, 5, 11)));  // output: spring

            static string GetCalendarSeason(DateTime date) => date.Month switch
            {
                3 or 4 or 5 => "spring",
                6 or 7 or 8 => "summer",
                9 or 10 or 11 => "autumn",
                12 or 1 or 2 => "winter",
                _ => throw new ArgumentOutOfRangeException(nameof(date), $"Date with unexpected month: {date.Month}."),
            };
            // </OrPattern>
        }

        // <WithParentheses>
        static bool IsLetter(char c) => c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z');
        // </WithParentheses>

        private static void ChangedPrecedence(object input)
        {
            // <ChangedPrecedence>
            if (input is not (float or double))
            {
                return;
            }
            // </ChangedPrecedence>
        }
    }
}
