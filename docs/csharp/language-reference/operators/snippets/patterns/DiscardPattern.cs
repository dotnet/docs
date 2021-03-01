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
            Console.WriteLine(NumberToAction(1));  // output: run
            Console.WriteLine(NumberToAction(7413));  // output: do nothing
            Console.WriteLine(NumberToAction(null));  // output: do nothing

            static string NumberToAction(int? number) => number switch
            {
                0 => "cook",
                1 => "run",
                2 => "think",
                _ => "do nothing",
            };
            // </BasicExample>
        }
    }
}