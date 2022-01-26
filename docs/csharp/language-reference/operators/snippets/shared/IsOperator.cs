using System;

namespace operators
{
    public static class IsOperator
    {
        public static void Examples()
        {
            DeclarationPattern();
        }

        // <IntroExample>
        static bool IsFirstFridayOfOctober(DateTime date) =>
            date is { Month: 10, Day: <=7, DayOfWeek: DayOfWeek.Friday };
        // </IntroExample>

        private static void DeclarationPattern()
        {
            // <DeclarationPattern>
            int i = 34;
            object iBoxed = i;
            int? jNullable = 42;
            if (iBoxed is int a && jNullable is int b)
            {
                Console.WriteLine(a + b);  // output 76
            }
            // </DeclarationPattern>
        }

        private static void NullCheck(object input)
        {
            // <NullCheck>
            if (input is null)
            {
                return;
            }
            // </NullCheck>
        }

        private static void NonNullCheck(object result)
        {
            // <NonNullCheck>
            if (result is not null)
            {
                Console.WriteLine(result.ToString());
            }
            // </NonNullCheck>
        }
    }
}
