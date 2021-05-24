using System;

namespace IterationStatements
{
    public static class DoStatement
    {
        public static void Examples()
        {
            Example();
        }

        private static void Example()
        {
            // <Example>
            int n = 0;
            do
            {
                Console.Write(n);
                n++;
            } while (n < 5);
            // Output:
            // 01234
            // </Example>
            Console.WriteLine();
        }
    }
}