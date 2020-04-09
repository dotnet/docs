using System;

namespace operators
{
    public class ConditionalOperator
    {
        public static void Examples()
        {
            ConditionalRefExpressions();
            ConditionalValueExpressions();
            ComparisonWithIf();
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

        private static void ConditionalValueExpressions()
        {
            // <SnippetConditionalValue>
            double sinc(double x) => x != 0.0 ? Math.Sin(x) / x : 1;

            Console.WriteLine(sinc(0.1));
            Console.WriteLine(sinc(0.0));
            // Output:
            // 0.998334166468282
            // 1
            // </SnippetConditionalValue>
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
