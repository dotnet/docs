using System.Linq;
using System;
namespace Projection
{
    public class SelectSample7
    {
        //This sample uses select and query syntax to produce a sequence containing text representations of digits and
        //whether their length is even or odd.
        //
        //Outputs:
        // Number: In-place?
        // 5: False
        // 4: False
        // 1: False
        // 3: True
        // 9: False
        // 8: False
        // 6: True
        // 7: True
        // 2: False
        // 0: False
        public static void Example()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var numsInPlace = numbers.Select((num, index) => new { Num = num, InPlace = (num == index) });

            Console.WriteLine("Number: In-place?");
            foreach (var n in numsInPlace)
            {
                Console.WriteLine($"{n.Num}: {n.InPlace}");
            }
        }
    }
}