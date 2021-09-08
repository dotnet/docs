using System;

namespace Patterns
{
    public static class ConstantPattern
    {
        public static void Examples()
        {
            Console.WriteLine(GetGroupTicketPrice(2));
        }

        // <BasicExample>
        public static decimal GetGroupTicketPrice(int visitorCount) => visitorCount switch
        {
            1 => 12.0m,
            2 => 20.0m,
            3 => 27.0m,
            4 => 32.0m,
            0 => 0.0m,
            _ => throw new ArgumentException($"Not supported number of visitors: {visitorCount}", nameof(visitorCount)),
        };
        // </BasicExample>

        private static void NullCheck(object input)
        {
            // <NullCheck>
            if (input is null)
            {
                return;
            }
            // </NullCheck>
        }

        private static void NonNullCheck(object input)
        {
            // <NonNullCheck>
            if (input is not null)
            {
                // ...
            }
            // </NonNullCheck>
        }
    }
}