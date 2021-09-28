using System;
using System.Collections.Generic;

namespace operators
{
    public class ConditionalOperator
    {
        public static void Examples()
        {
            BasicExample();
            ConditionalRefExpressions();
            ComparisonWithIf();
            TargetTyped();
            NotTargetTyped();
        }

        private static void BasicExample()
        {
            // <BasicExample>
            string GetWeatherDisplay(double tempInCelsius) => tempInCelsius < 20.0 ? "Cold." : "Perfect!";
            
            Console.WriteLine(GetWeatherDisplay(15));  // output: Cold.
            Console.WriteLine(GetWeatherDisplay(27));  // output: Perfect!
            // </BasicExample>
        }

        private static void ConditionalRefExpressions()
        {
            // <SnippetConditionalRef>
            var smallArray = new int[] { 1, 2, 3, 4, 5 };
            var largeArray = new int[] { 10, 20, 30, 40, 50 };

            int index = 7;
            ref int refValue = ref ((index < 5) ? ref smallArray[index] : ref largeArray[index - 5]);
            refValue = 0;

            index = 2;
            ((index < 5) ? ref smallArray[index] : ref largeArray[index - 5]) = 100;

            Console.WriteLine(string.Join(" ", smallArray));
            Console.WriteLine(string.Join(" ", largeArray));
            // Output:
            // 1 2 100 4 5
            // 10 20 0 40 50
            // </SnippetConditionalRef>
        }

        private static void TargetTyped()
        {
            // <SnippetTargetTyped>
            var rand = new Random();
            var condition = rand.NextDouble() > 0.5;

            int? x = condition ? 12 : null;

            IEnumerable<int> xs = x is null ? new List<int>() { 0, 1 } : new int[] { 2, 3 };
            // </SnippetTargetTyped>
        }

        private static void NotTargetTyped()
        {
            // <SnippetNotTargetTyped>
            var rand = new Random();
            var condition = rand.NextDouble() > 0.5;

            var x = condition ? 12 : (int?)null;
            // </SnippetNotTargetTyped>
        }

        private static void ComparisonWithIf()
        {
            // <SnippetCompareWithIf>
            int input = new Random().Next(-5, 5);

            string classify;
            if (input >= 0)
            {
                classify = "nonnegative";
            }
            else
            {
                classify = "negative";
            }

            classify = (input >= 0) ? "nonnegative" : "negative";
            // </SnippetCompareWithIf>
        }
    }
}
