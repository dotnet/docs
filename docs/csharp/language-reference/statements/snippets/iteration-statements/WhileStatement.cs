using System;

namespace IterationStatements
{
    public static class WhileStatement
    {
        public static void Examples()
        {
            Example();
        }

        private static void Example()
        {
            // <Example>
            int n = 0;
            while (n < 5)
            {
                Console.WriteLine(n);
                n++;
            }
            // </Example>
        }
    }
}