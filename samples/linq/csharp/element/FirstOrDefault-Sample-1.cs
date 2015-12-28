using System;
using System.Linq;

namespace Element
{
    public static class FirstOrDefaultSample1
    {
        //This sample uses FirstOrDefault to try to return the first element of the sequence,
        //unless there are no elements, in which case the default value for that type
        //is returned. FirstOrDefault is useful for creating outer joins.
        //
        //Output: 
        // 0
        public static void Example()
        {
            int[] numbers = { };

            int firstNumOrDefault = numbers.FirstOrDefault();

            Console.WriteLine(firstNumOrDefault);
        }
    }
}