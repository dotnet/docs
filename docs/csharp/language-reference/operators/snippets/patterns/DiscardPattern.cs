using System;

namespace Patterns
{
    public static class DiscardPattern
    {
        public static void Examples()
        {
            BasicExample();
        }

        private static void BasicExample()
        {
            // <BasicExample>
            Console.WriteLine(GetDiscountInPercent(DayOfWeek.Friday));  // output: 5.0
            Console.WriteLine(GetDiscountInPercent(null));  // output: 0.0
            Console.WriteLine(GetDiscountInPercent((DayOfWeek)10));  // output: 0.0

            static decimal GetDiscountInPercent(DayOfWeek? dayOfWeek) => dayOfWeek switch
            {
                DayOfWeek.Monday => 0.5m,
                DayOfWeek.Tuesday => 12.5m,
                DayOfWeek.Wednesday => 7.5m,
                DayOfWeek.Thursday => 12.5m,
                DayOfWeek.Friday => 5.0m,
                DayOfWeek.Saturday => 2.5m,
                DayOfWeek.Sunday => 2.0m,
                _ => 0.0m,
            };
            // </BasicExample>
        }
    }
}