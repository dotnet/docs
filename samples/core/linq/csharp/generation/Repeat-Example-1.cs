using System;
using System.Linq;

namespace Generation
{
    public static class RepeatExample1
    {
        //This sample uses Repeat to generate a sequence that contains the number 7 seven times.
        //
        //Output: 
        // 7
        // 7
        // 7
        // 7
        // 7
        // 7
        // 7
        public static void Example()
        {
            var numbers = Enumerable.Repeat(7, 7);

            foreach (var n in numbers)
            {
                Console.WriteLine(n);
            }
        }
    }
}