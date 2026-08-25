using System;

namespace ca2014
{
    public class Example
    {
        //<snippet1>
        // This method violates the rule.
        public void ProcessDataBad()
        {
            for (int i = 0; i < 100; i++)
            {
                // CA2014: Potential stack overflow.
                // Move the stackalloc out of the loop.
                Span<int> buffer = stackalloc int[100];
                buffer[0] = i;

                // ...
            }
        }

        // This method satisfies the rule.
        public void ProcessDataGood()
        {
            Span<int> buffer = stackalloc int[100];

            for (int i = 0; i < 100; i++)
            {
                buffer[0] = i;

                // ...
            }
        }
        //</snippet1>
    }
}
